using ClosedXML.Excel;
using File_Sharing.Areas.Admin.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace File_Sharing.Areas.Admin
{
    public static class AdminStartup
    {
        // Extension Method
        public static IServiceCollection AddAdminServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IContactUsService, ContactUsService>();
            services.AddTransient<IXLWorkbook, XLWorkbook>();

            return services;
        }

    }
}
