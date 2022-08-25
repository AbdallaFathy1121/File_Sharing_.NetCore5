using ClosedXML.Excel;
using File_Sharing.Areas.Admin.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace File_Sharing.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = UserRoles.Admin)]
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IXLWorkbook workbook;
        public UserController(IUserService userService, IXLWorkbook workbook)
        {
            this.userService = userService;
            this.workbook = workbook;
        }

        // Route => Admin/User
        // Page Get All Users
        public async Task<IActionResult> Index()
        {
            var result = await userService.GetAllUsers().ToListAsync();

            return View(result);
        }

        // Route Admin/User/Blocked
        // Page Get All blockedUser
        public async Task<IActionResult> Blocked()
        {
            var result = await userService.GetBlockedUsers().ToListAsync();

            return View(result);
        }

        // Action To search About Users
        [HttpPost]
        public async Task<IActionResult> Search(string term)
        {
            if (!String.IsNullOrEmpty(term))
            {
                var result = await userService.Search(term).ToListAsync();
                return View("Index", result);
            }

            return RedirectToAction("Index");
        }

        // Action Block User By Id
        [HttpPost]
        public async Task<IActionResult> Block(string userId)
        {
            if (!String.IsNullOrEmpty(userId))
            {
                var result = await userService.ToggleBlockUser(userId);
                if (result.Success)
                {
                    TempData["Success"] = result.Message;
                }
                else
                {
                    TempData["Error"] = result.Message;
                }
                return RedirectToAction("Index");
            }
            
            TempData["Error"] = "User is Not Found";
            return RedirectToAction("Index");
        }

        // Route => Admin/User/UsersCount
        public async Task<IActionResult> UsersCount()
        {
            var result = await userService.UserRegistrationCount();

            return Json(new { total = result });
        }

        // Action Export All Users Into Sheet Excel
        public async Task<IActionResult> ExportToExcel()
        {
            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            string fileName = "Users.xlsx";

            var result = await userService.GetAllUsers().ToListAsync();

            var worksheet = workbook.Worksheets.Add("All Users");
            worksheet.Cell(1, 1).Value = "User Id";
            worksheet.Cell(1, 2).Value = "Email";
            worksheet.Cell(1, 3).Value = "Is Allowed";

            for (int i = 1; i < result.Count; i++)
            {
                var row = i + 1;
                worksheet.Cell(row, 1).Value = result[i - 1].Id;
                worksheet.Cell(row, 2).Value = result[i - 1].Email;
                worksheet.Cell(row, 3).Value = result[i - 1].LockoutEnabled;
            }

            using (var ms = new MemoryStream())
            {
                workbook.SaveAs(ms);
                return File(ms.ToArray(), contentType, fileName);
            }
        }




    }
}
