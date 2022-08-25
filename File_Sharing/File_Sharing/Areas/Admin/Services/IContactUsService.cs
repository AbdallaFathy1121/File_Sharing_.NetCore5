using AutoMapper;
using AutoMapper.QueryableExtensions;
using File_Sharing.Areas.Admin.ViewModels;
using File_Sharing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace File_Sharing.Areas.Admin.Services
{
    public interface IContactUsService
    {
        IQueryable<ContactUsViewModel> GetAll();
        Task ChangeStatusAsync(string id, bool status);
    }


    public class ContactUsService : IContactUsService
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        public ContactUsService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IQueryable<ContactUsViewModel> GetAll()
        {
            var result = context.Contacts.ProjectTo<ContactUsViewModel>(mapper.ConfigurationProvider);

            return result;
        }

        public async Task ChangeStatusAsync(string id, bool status)
        {
            var selectedItem = await context.Contacts.FindAsync(id);
            if (selectedItem != null)
            {
                selectedItem.Status = status;
                context.Update(selectedItem);
                await context.SaveChangesAsync();
            }
        }

    }
}
