using System.ComponentModel.DataAnnotations;

namespace CMScenter.Views.Models
{
    public class CourseCategory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="arabic Name")]
        public string arName { get; set; }  
        [Required]
        [Display(Name ="english Name")]
        public string enName { get; set; }
        [Required]
        [Display(Name = "arabic description")]
        public string arDescription { get; set; }
        [Required]
        [Display(Name = "english description")]
        public string enDescription { get; set; }
    }
}
