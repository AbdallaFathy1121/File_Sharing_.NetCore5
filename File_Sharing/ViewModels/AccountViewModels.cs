using File_Sharing.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace File_Sharing.ViewModels
{
    public class LoginViewModel
    {
        [EmailAddress(ErrorMessageResourceName = "Email", ErrorMessageResourceType = typeof(SharedResource))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(SharedResource))]
        [Display(Name = "EmailLabel", ResourceType = typeof(SharedResource))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(SharedResource))]
        [Display(Name = "PasswordLabel", ResourceType = typeof(SharedResource))]
        public string Password { get; set; }
    }


    public class RegisterViewModel
    {
        [EmailAddress(ErrorMessageResourceName = "Email", ErrorMessageResourceType = typeof(SharedResource))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(SharedResource))]
        [Display(Name = "EmailLabel", ResourceType = typeof(SharedResource))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(SharedResource))]
        [Display(Name = "PasswordLabel", ResourceType = typeof(SharedResource))]
        public string Password { get; set; }

        [Compare("Password", ErrorMessageResourceName = "Compare", ErrorMessageResourceType = typeof(SharedResource))]
        public string ConfirmPassword { get; set; }
    }

}
