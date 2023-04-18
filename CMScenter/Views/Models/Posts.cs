using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace CMScenter.Views.Models
{
    public class Posts
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="arabic title")]
        public string arTitle { get; set; }
        [Required]
        [Display(Name ="english title")]
        public string enTitle { get; set; } 
        [Required]
        [Display(Name ="arabic description")]
        public string arDes { get; set; }
        [Required]
        [Display(Name ="english description")]
        public string enDes { get; set; }
        [ValidateNever]
        public string PostImage { get; set; }

        /// <summary>
        ///  foteng key
        /// </summary>
        ///          
        [Display(Name = "post Cateogry")]
        public int postsCategoryId { get; set; }
        public PostsCategory postsCategory { get; set; }
    
        public DateTime postDate { get; set; } = DateTime.Now;


    }
}
