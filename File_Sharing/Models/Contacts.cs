using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace File_Sharing.Models
{
    public class Contacts
    {
        // Constractor => Generate UploadId by Guid
        public Contacts() => ContactId = Guid.NewGuid().ToString();

        // Colums
        [Key]
        public string ContactId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        
        [ForeignKey("User")]
        public string UserId { get; set; }

        // Relations
        public virtual IdentityUser User { get; set; }

    }
}
