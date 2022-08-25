using File_Sharing.Areas.Admin.ViewModels;
using File_Sharing.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace File_Sharing.Areas.Admin.Services
{
    public interface IUserService
    {
        IQueryable<IdentityUser> GetAllUsers();
        IQueryable<IdentityUser> GetBlockedUsers();
        IQueryable<IdentityUser> Search(string term);
        Task<OperationResult> ToggleBlockUser(string userId);
        Task<int> UserRegistrationCount();
        Task Initialize();
    }

    public class UserService : IUserService
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public UserService(ApplicationDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }


        public async Task<OperationResult> ToggleBlockUser(string userId)
        {
            var user = await context.Users.FindAsync(userId);
            if (user == null)
                return OperationResult.NotFound();

            user.LockoutEnabled = !user.LockoutEnabled;

            if (user.LockoutEnabled == false)
                // LogOut User Who is Blocked
                await userManager.UpdateSecurityStampAsync(user);

            context.Update(user);
            await context.SaveChangesAsync();

            return OperationResult.Succeeded();
        }
            
        public IQueryable<IdentityUser> GetAllUsers()
        {
            IQueryable<IdentityUser> result = context.Users;

            return result;
        }

        public IQueryable<IdentityUser> GetBlockedUsers()
        {
            IQueryable<IdentityUser> result = context.Users.Where(x => x.LockoutEnabled == false);

            return result;
        }

        public IQueryable<IdentityUser> Search(string term)
        {
            IQueryable<IdentityUser> result = context.Users.Where(x => x.UserName.Contains(term));

            return result;
        }

        public async Task<int> UserRegistrationCount()
        {
            var count = await context.Users.CountAsync();

            return count;
        }

        // Create New User Role(Admin) When Deployment This Project  
        public async Task Initialize()
        {
            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            }

            var adminEmail = "admin@gmail.com";
            if(await userManager.FindByEmailAsync(adminEmail) == null)
            {
                var user = new IdentityUser
                {
                    Email = adminEmail,
                    UserName = adminEmail
                };

                await userManager.CreateAsync(user, "Abdalla0159357");
                await userManager.AddToRoleAsync(user, UserRoles.Admin);
            }





        }
    }
}
