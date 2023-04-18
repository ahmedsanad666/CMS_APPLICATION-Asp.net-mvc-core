using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace CMScenter.Views.Models
{
    public class Services
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name=(" اسم الخدمة"))]
        public string arName { get; set; }
        [Required]
        [Display(Name=(" service Name"))]
        public string enName { get; set; }
        [Required]
        [StringLength(5000)]
        public string arDescription { get; set; } [Required]
        [StringLength(5000)]
        public string enDescription { get; set; }
        [Required]
        [Display(Name="Link")]
        public string CourseLink { get; set; }
       
        [ValidateNever]
        public string Image { get; set; }
        [Required]
        [Display(Name="Constructor Name")]

        public string ConstructorName { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
      
            
        [Display(Name = "Category")]
        public int CourseCategoryId { get; set; }
        public CourseCategory courseCategory { get; set; }
        public DateTime LastUpdated { get; set; } = DateTime.Now;



    }
}
