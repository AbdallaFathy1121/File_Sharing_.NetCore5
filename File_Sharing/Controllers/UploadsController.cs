using File_Sharing.Bl;
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
        IUploadsService UploadsService;
        private readonly IWebHostEnvironment env;
        private readonly ApplicationDbContext context;
        public UploadsController(IUploadsService _Uploads, IWebHostEnvironment env, ApplicationDbContext context)
        {
            UploadsService = _Uploads;
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

        // View My Uploads
        // Route => Uploads/Index
        public IActionResult Index()
        {
            var result = UploadsService.GetUploadsByUserId(UserId);
            return View(result);
        }

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

        // Delete Upload By Id
        public async Task<IActionResult> Delete(string id)
        {
            var upload = await context.Uploads.FindAsync(id);
            
            if (upload == null)
                return NotFound();

            context.Uploads.Remove(upload);
            await context.SaveChangesAsync();

            return RedirectToAction("Index");

        }



    }
}
