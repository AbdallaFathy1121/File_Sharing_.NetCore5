using File_Sharing.Models;
using File_Sharing.Services;
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
        private readonly IUploadService uploadService;
        public UploadsController(IWebHostEnvironment env, IUploadService uploadService)
        {
            this.env = env;
            this.uploadService = uploadService;
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
            return View(uploadService.GetByUserId(UserId));
        }

        // View Page All Uploads
        // Route => Uploads/Browse
        [AllowAnonymous]
        public async Task<IActionResult> Browse(int requiredPage = 1)
        {
            var result = uploadService.GetAll();

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
        public async Task<IActionResult> Create(InputFile model)
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

                await uploadService.Create(new InputUpload
                {
                    OriginalFileName = _fileName,
                    FileName = fileName,
                    ContentType = model.File.ContentType,
                    Size = model.File.Length,
                    UserId = UserId
                });

                return RedirectToAction("Index");
            }
            return View(model);
        }

        // Action Delete File By Id
        public async Task<IActionResult> Delete(string id)
        {
            var upload = await uploadService.Find(id, UserId);
            
            if (upload == null )
                return NotFound();

            await uploadService.Delete(id, UserId);

            return RedirectToAction("Index");

        }

        // Form Search Uploads By File Name
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Results(string term)
        {
            return View(uploadService.Search(term));
        }
        
        // Action Download File
        public async Task<IActionResult> Download(string id)
        {
            var selectedFile = await uploadService.Find(id);

            if (selectedFile == null)
                return NotFound();


            await uploadService.IncreamentDownloadCount(id);

            var path = "~/Uploads/" + selectedFile.FileName;

            // Clear Cache
            Response.Headers.Add("Expires", DateTime.Now.AddDays(-3).ToLongDateString());
            Response.Headers.Add("Cache-Control", "no-cache");

            return File(path, selectedFile.ContentType, selectedFile.OriginalFileName);
        
        }


    }
}
