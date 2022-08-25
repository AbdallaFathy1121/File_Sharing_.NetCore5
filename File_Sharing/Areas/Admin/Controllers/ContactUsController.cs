using File_Sharing.Areas.Admin.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace File_Sharing.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = UserRoles.Admin)]
    public class ContactUsController : Controller
    {
        private readonly IContactUsService contactUsService;
        public ContactUsController(IContactUsService contactUsService)
        {
            this.contactUsService = contactUsService;
        }

        // Route => Admin/ContactUs
        // Page View  Contacts
        public async Task<IActionResult> Index()
        {
            var result = await contactUsService.GetAll().ToListAsync();

            return View(result);
        }

        // Form Change Status
        [HttpPost]
        public async Task<IActionResult> ChangeStatus(string id, bool status)
        {
            await contactUsService.ChangeStatusAsync(id, status);

            return RedirectToAction("Index");
        }
    }
}
