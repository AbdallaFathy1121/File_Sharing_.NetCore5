using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace File_Sharing
{
    public class UploadProfile : Profile
    {
        public UploadProfile()
        {
            CreateMap<ViewModels.InputUpload, Models.Uploads>()
                .ForMember(x => x.CreationDate, op => op.Ignore())
                .ForMember(x => x.UploadId, op => op.Ignore());


            CreateMap<Models.Uploads, ViewModels.UploadViewModel>();
        }
    }


    public class ContactUsProfile : Profile
    {
        public ContactUsProfile()
        {
            CreateMap<Models.Contacts, Areas.Admin.ViewModels.ContactUsViewModel>();
        }
    }


}
