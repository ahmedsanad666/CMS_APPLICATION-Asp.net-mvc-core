

using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace CMScenter.Views.Models
{
    public class AppSittings
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Logo { get; set; }
       
        [Required]
        [Display(Name ="arabic Name")]
        
        public string arName { get; set; }
        [Required]
        [Display(Name ="english Name ")]
        public string enName { get; set; }
        [Required]
        [Display(Name="Video Url")]
        public string AboutAs_video { get; set; }
        [Required]
        [Display(Name = "about us arabic ")]
        [StringLength(5000, MinimumLength =100, ErrorMessage = "must be between 5 and 50 letters")]
        public string arAboutUs  { get; set; }
        [Required]
        [Display(Name = "about us english ")]
        public string enAboutUs { get; set; }
        [Required]
        [Display(Name = "our vision arabic")]
        [StringLength(5000, MinimumLength = 100, ErrorMessage = "must be between 5 and 50 letters")]
        public string arVision  { get; set; }

        [Required]
        [Display(Name = "our vision english")]

        public string enVision { get; set; }
        [Display(Name = "Launch Date")]
        public DateTime LaunchDate { get; set; }

        // fogrein Keys

        [Required]
        [Display(Name ="facebook")]
        public string FaceBook { get; set; }
        [Required]
        [Display(Name = "twitter")]

        public string Twitter { get; set; }
        [Required]
        [Display(Name = "youtube")]

        public string Youtube { get; set; }
        [Required]
        [Display(Name = "adminEmail")]

        public string AdminEmail { get; set; }
        [Required]
        [Display(Name = "Telefon number")]
        public string TelefonNum { get; set; }

        [Required]
        public int Committees { get; set; }
        [Required]
        [Display(Name = "Team Members")]
        public int TeamMembers { get; set; }
        [Required]
        public int Beneficiaries { get; set; }
        [Required]
        [Display(Name = "Scientific Activities")]
        public int ScientificActivities { get; set; }

        //slider images 
        [ValidateNever]
        public string SliderImage1 { get; set; }  
        [ValidateNever]
        public string SliderImage2 { get; set; }  
        [ValidateNever]
        public string SliderImage3 { get; set; }

        public DateTime LastUpdated { get; set; } = DateTime.Now;



    }
}
