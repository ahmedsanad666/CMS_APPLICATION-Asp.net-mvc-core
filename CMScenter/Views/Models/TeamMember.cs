using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace CMScenter.Views.Models
{
    public class TeamMember
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="الاسم")]
        public string arName { get; set; } 
        [Required]
        public string enName { get; set; }
        [Required]
        [Display(Name="نبذة مختصره")]
        public string arBriefDes { get; set; }
        [Required]
        [Display(Name=" Brief description")]
        public string enBriefDes { get; set; }
        [Required]
        [Display(Name ="المنصب")]
        public string arPosition { get; set; }  [Required]
        public string enPosition { get; set; }
        [ValidateNever]
        public string Image { get; set; }
        
        [Required]
        public string FaceBook { get; set; }
        [Required]
        public string Twitter { get; set; }
        [Required]
        public string Youtube { get; set; }
       [Required]
        public string Instagram { get; set; }
     
        [Required]
        [Display(Name = "Telefon number")]
        public string TelefonNum { get; set; }


        public DateTime LastUpdated { get; set; } = DateTime.Now;
    }
}
