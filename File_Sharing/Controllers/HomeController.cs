using File_Sharing.Models;
using File_Sharing.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
