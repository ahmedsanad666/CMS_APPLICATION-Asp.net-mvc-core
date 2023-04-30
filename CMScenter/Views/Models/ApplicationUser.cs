using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace CMScenter.Views.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [Display(Name = "arabic Name ")]
        public string ArName { get; set; }

        [Required]
        [Display(Name = "arabic Name ")]
        public string EnName { get; set; }

        // user interface
    }
}
