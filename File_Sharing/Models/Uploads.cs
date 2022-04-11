using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace File_Sharing.Models
{
    public class Uploads
    {
        // Constractor => Generate UploadId by Guid
        public Uploads() => UploadId = Guid.NewGuid().ToString();

        // Colums
        [Key]
        public string UploadId { get; set; }
        public string OriginalFileName { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public decimal Size { get; set; }
        public DateTime CreationDate { get; set; }
        public string UserId { get; set; }

        // Relations
        public IdentityUser User { get; set; }

    }
}
