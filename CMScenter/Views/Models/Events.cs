using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace CMScenter.Views.Models
{
    public class Events
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="arabic name")]
        public string arName { get; set; }
        [Required]
        [Display(Name ="english name")]
        public string enName { get; set; }
        [Required]
        [Display(Name ="arabic description")]
        public string ardes { get; set; }
        [Required]
        [Display(Name ="english description")]
        public string endes { get; set; }
        [ValidateNever]
        public string EventImag { get; set; }
    
        public string EventLink { get; set; } 

    }
}
