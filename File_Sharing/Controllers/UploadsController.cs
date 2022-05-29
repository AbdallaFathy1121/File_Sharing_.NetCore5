using File_Sharing.Models;
using File_Sharing.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace File_Sharing.Controllers
{
    [Authorize]
    public class UploadsController : Controller
    {
        // Dependency Injection
        private readonly IWebHostEnvironment env;
        private readonly ApplicationDbContext context;
        public UploadsController(IWebHostEnvironment env, ApplicationDbContext context)
        {
            this.env = env;
            this.context = context;
        }

        // Get UserId
        private string UserId { 
            get 
            {
                return User.FindFirstValue(ClaimTypes.NameIdentifier);
            } 
        }

        // Get PagedData To Create Pagination
        private async Task<List<UploadViewModel>> GetPagedData(IQueryable<UploadViewModel> result, int requiredPage = 1)
        {
            const int pageSize = 3;

            decimal rowsCount = await result.CountAsync();
            var pagesCount = Math.Ceiling(rowsCount / pageSize);

            if(requiredPage <= 0)
                requiredPage = 1;
            if(requiredPage > pagesCount)
                requiredPage = 1;


            int skipCount = (requiredPage - 1) * pageSize;
                       
            var pagedData = await result 
                .Skip(skipCount)
                .Take(pageSize)
                .ToListAsync();

            ViewBag.CurrentPage = requiredPage;
            ViewBag.PagesCount = pagesCount;

            return pagedData;
        }

        // View Page My Uploads
        // Route => Uploads/Index
        public IActionResult Index()
        {
            var result = context.Uploads.Where(a => a.UserId == UserId)
                .OrderByDescending(s => s.DownloadCount)
                .Select(a => new UploadViewModel
                {
                    UploadId = a.UploadId,
                    OriginalFileName = a.OriginalFileName,
                    FileName = a.FileName,
                    ContentType = a.ContentType,
                    Size = a.Size,
                    CreationDate = a.CreationDate,
                    DownloadCount = a.DownloadCount
                });

            return View(result);
        }

        // View Page All Uploads
        // Route => Uploads/Browse
        [AllowAnonymous]
        public async Task<IActionResult> Browse(int requiredPage = 1)
        {
            var result = context.Uploads
                .OrderByDescending(s => s.DownloadCount)
                .Select(a => new UploadViewModel
                {
                      UploadId = a.UploadId,
                      OriginalFileName = a.OriginalFileName,
                      FileName = a.FileName,
                      ContentType = a.ContentType,
                      Size = a.Size,
                      CreationDate = a.CreationDate,
                      DownloadCount = a.DownloadCount
                });

            var model = await GetPagedData(result, requiredPage);

            return View(model);
        }

        // View Page Create Upload
        // Route => Uploads/Create
        public IActionResult Create()
        {
            return View();
        }

        // Form Add New Upload
        [HttpPost]
        public async Task<IActionResult> Create(InputUploadViewModel model)
        {
            if(ModelState.IsValid)
            {
                var _fileName = model.File.FileName;
                string newName = Guid.NewGuid().ToString();
                var extension = Path.GetExtension(_fileName);
                var fileName = string.Concat(newName, extension);
                var root = env.WebRootPath;
                var path = Path.Combine(root, "Uploads", fileName);

                using (var fs = System.IO.File.Create(path))
                {
                    await model.File.CopyToAsync(fs);
                }

                await context.Uploads.AddAsync(new Uploads
                {
                    OriginalFileName = _fileName,
                    FileName = fileName,
                    ContentType = model.File.ContentType,
                    Size = model.File.Length,
                    CreationDate = DateTime.Now,
                    UserId = UserId
                });
                await context.SaveChangesAsync();    

                return RedirectToAction("Index");
            }
            return View(model);
        }

        // Action Delete File By Id
        public async Task<IActionResult> Delete(string id)
        {
            var upload = await context.Uploads.FindAsync(id);
            
            if (upload == null || upload.UserId != UserId)
                return NotFound();

            context.Uploads.Remove(upload);
            await context.SaveChangesAsync();

            return RedirectToAction("Index");

        }

        // Form Search Uploads By File Name
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Results(string term, int requiredPage = 1)
        {
            var result = await context.Uploads
                .Where(a => a.OriginalFileName.Contains(term))
                .OrderByDescending(s => s.DownloadCount)
                .Select(a => new UploadViewModel
                {
                    OriginalFileName = a.OriginalFileName,
                    FileName = a.FileName,
                    ContentType = a.ContentType,
                    Size = a.Size,
                    CreationDate = a.CreationDate,
                    DownloadCount = a.DownloadCount
                })
                .Take(10)
                .ToListAsync();

            return View(result);
        }
        
        // Action Download File
        public async Task<IActionResult> Download(string id)
        {
            var selectedFile = await context.Uploads.FirstOrDefaultAsync(a => a.FileName == id);

            if (selectedFile == null)
                return NotFound();

            selectedFile.DownloadCount++;
            context.Update(selectedFile);
            await context.SaveChangesAsync();

            var path = "~/Uploads/" + selectedFile.FileName;

            // Clear Cache
            Response.Headers.Add("Expires", DateTime.Now.AddDays(-3).ToLongDateString());
            Response.Headers.Add("Cache-Control", "no-cache");

            return File(path, selectedFile.ContentType, selectedFile.OriginalFileName);
        
        }


    }
}
