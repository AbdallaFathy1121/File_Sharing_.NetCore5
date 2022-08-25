using File_Sharing.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace File_Sharing.Areas.Admin.ViewModels
{
    public class ContactUsViewModel : ContactViewModel
    {
        public string UserId { get; set; }
        public string ContactId { get; set; }
        public bool Status { get; set; }
        public DateTime SentDate { get; set; }
    }
}
