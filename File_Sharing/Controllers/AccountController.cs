using File_Sharing.Models;
using File_Sharing.Resources;
using File_Sharing.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using QuickMailer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace File_Sharing.Controllers
{
    public class AccountController : Controller
    {
        // Use SignInManager and UserManager
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IStringLocalizer<SharedResource> stringLocalizer;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IStringLocalizer<SharedResource> stringLocalizer)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.stringLocalizer = stringLocalizer;
        }

        // View Page Login
        // Route => Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Form Login
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if(ModelState.IsValid)
            {
                var existedUser = await userManager.FindByEmailAsync(model.Email);
                if (existedUser == null)
                {
                    TempData["Error"] = "Invalid Email or Password";
                    return View(model);
                }
                if (existedUser.LockoutEnabled == true)
                {
                    var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, false, true);
                    if (result.Succeeded)
                    {
                        if (!string.IsNullOrEmpty(returnUrl))
                            return LocalRedirect(returnUrl);
                        else
                            return RedirectToAction("Create", "Uploads");
                    }
                }
                else
                {
                    TempData["Error"] = "This Account Has been Blocked";
                }
            }
            return View(model);
        }

        /// /////////////////////////////////////////////////////

        // View Page Register
        // Route => Account/Register
        public IActionResult Register()
        {
            return View();
        }

        // Form Register
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, true);
                    return RedirectToAction("Create", "Uploads");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        /// /////////////////////////////////////////////////////

        // Action LogOut
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        /// /////////////////////////////////////////////////////

        // External Login (Provider)
        public IActionResult ExternalLogin(string provider) // Provider = "Facebook", "Google"
        {
            var properties = signInManager.ConfigureExternalAuthenticationProperties(provider, "/Account/ExternalResponse");

            return Challenge(properties, provider);
        }

        public async Task<IActionResult> ExternalResponse()
        {
            var info = await signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                TempData["message"] = "Login Faild";
                return RedirectToAction("Login");
            }

            var loginResult = await signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, false);
            if (!loginResult.Succeeded)
            {
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);
                // Create Local Account
                var userToCreate = new IdentityUser
                {
                    Email = email,
                    UserName = email
                };

                var createResult = await userManager.CreateAsync(userToCreate); // AspNetUsers
                if (createResult.Succeeded)
                {
                    var exLoginResult = await userManager.AddLoginAsync(userToCreate, info); // AspNetUserLogins
                    if (exLoginResult.Succeeded)
                    {
                        await signInManager.SignInAsync(userToCreate, false, info.LoginProvider);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        await userManager.DeleteAsync(userToCreate);
                    }
                }
                
                return RedirectToAction("Login");
            }

            var emailUser = info.Principal.FindFirstValue(ClaimTypes.Email);

            var existedUser = await userManager.FindByEmailAsync(emailUser);
            if (existedUser == null)
            {
                TempData["Error"] = "Invalid Email or Password";
                return RedirectToAction("Login");
            }
            if(existedUser.LockoutEnabled == false)
            {
                await signInManager.SignOutAsync();
                TempData["Error"] = "This Account Has been Blocked";
                return RedirectToAction("Login");
            }

            return RedirectToAction("Index", "Home");
        }

        /////////////////////////////////////////////////////////

        // View Info Page
        // Route => Home/Info
        public async Task<IActionResult> Info()
        {
            var currentUser = await userManager.GetUserAsync(User);
            if(currentUser.PasswordHash != null)
            {
                TempData["changePass"] = "11";
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await userManager.GetUserAsync(User);
                if (currentUser != null)
                {
                    var result = await userManager.ChangePasswordAsync(currentUser, model.CurrentPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        TempData["Success"] = stringLocalizer["ChangePassword"]?.Value;
                        return RedirectToAction("Info");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                else
                {
                    return NotFound();
                }
            }

            return View("Info", model);
        }

        [HttpPost]
        public async Task<IActionResult> AddPassword(AddPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await userManager.GetUserAsync(User);
                if (currentUser != null)
                {
                    var result = await userManager.AddPasswordAsync(currentUser, model.Password);
                    if (result.Succeeded)
                    {
                        TempData["Success"] = stringLocalizer["AddPasswordMessage"]?.Value;
                        return RedirectToAction("Info");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                else
                {
                    return NotFound();
                }
            }

            return View("Info");
        }



    }
}
