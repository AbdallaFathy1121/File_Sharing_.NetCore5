using File_Sharing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace File_Sharing.Bl
{
    public interface IUploadsService
    {
        List<Uploads> GetUploadsByUserId(string id);
    }


    public class CLsUploads : IUploadsService
    {
        private readonly ApplicationDbContext context;
        public CLsUploads(ApplicationDbContext context)
        {
            this.context = context;
        }


        // Get List Uploads by UserId
        public List<Uploads> GetUploadsByUserId(string id)
        {
            var lstUploads = context.Uploads.Where(a => a.UserId == id).ToList();
            return lstUploads;
        }



    }

}
