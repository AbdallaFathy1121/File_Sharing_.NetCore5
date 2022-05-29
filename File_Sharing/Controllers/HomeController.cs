using File_Sharing.Models;
using File_Sharing.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace File_Sharing.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext context;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext _context)
        {
            _logger = logger;
            context = _context;
        }

        // Get UserId
        private string UserId
        {
            get
            {
                return User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
        }

        // View HomePage And List Of Top DownloadsCount
        // Route => Home/Index
        public async Task<IActionResult> Index()
        {
            var popularDownloads = await context.Uploads.OrderByDescending(a=> a.DownloadCount)
                .Select(a => new UploadViewModel
                {
                    UploadId = a.UploadId,
                    OriginalFileName = a.OriginalFileName,
                    FileName = a.FileName,
                    ContentType = a.ContentType,
                    Size = a.Size,
                    CreationDate = a.CreationDate,
                    DownloadCount = a.DownloadCount
                }).Take(4).ToListAsync();

            ViewBag.PopularDownloads = popularDownloads;

            return View();
        }

        // View Info Page
        // Route => Home/Info
        public IActionResult Info()
        {   
            return View();
        }

        // View About Page
        // Route => Home/About
        public IActionResult About()
        {
            return View();
        }

        // View Contact Page
        // Route => Home/Contact
        public IActionResult Contact()
        {
            return View();
        }

        // Form Add Contact
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                await context.Contacts.AddAsync(new Contacts
                {
                    Name = model.Name,
                    Email = model.Email,
                    Subject = model.Subject,
                    Message = model.Message,
                    UserId = UserId
                });
                await context.SaveChangesAsync();
                TempData["Message"] = "Message has been sent Successfully!..";
                return RedirectToAction("Contact");
            }
            return View(model);
        }


        // Switch Between Cultures
        public IActionResult SetCulture(string lang, string returnUrl)
        {
            if(!string.IsNullOrEmpty(lang))
            {
                Response.Cookies.Append(
                    CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(lang)),
                    new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
                );
            }
            return Redirect(returnUrl);
        }
        
    }
}
