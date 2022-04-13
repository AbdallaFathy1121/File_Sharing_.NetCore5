using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace File_Sharing.ViewModels
{
    public class InputUploadViewModel
    {
        [Required]
        public IFormFile File { get; set; }
    }

    public class UploadViewModel
    {
        public string UploadId { get; set; }
        public string OriginalFileName { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public decimal Size { get; set; }
        public DateTime CreationDate { get; set; }
        public long DownloadCount { get; set; }
    }

}
