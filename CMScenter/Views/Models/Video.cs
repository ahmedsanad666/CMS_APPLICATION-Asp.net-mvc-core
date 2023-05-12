using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using static CMScenter.Views.Models.Common;

namespace CMScenter.Views.Models
{
    public class Video
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [Display(Name = "Arabic Title")]
        [StringLength(500)]
        public string ArTitle { get; set; }

        [Display(Name = "English Title")]
        [StringLength(500)]
        public string EnTitle { get; set; }

        [Display(Name = "Arabic Description")]
        [StringLength(500)]
        public string ArDescription { get; set; }

        [Display(Name = "English Description")]
        [StringLength(500)]
        public string EnDescription { get; set; }

        [ValidateNever]
        public string Thumbnail { get; set; }

  
        public string Link { get; set; }

        public int Views { get; set; }

        public int Likes { get; set; }

        public int Shared { get; set; }

        public bool IsFeatured { get; set; }

        public bool IsPinned { get; set; } = true;

        // how to get array to database 
        [StringLength(100)]
        public string Tags { get; set; }

        [Display(Name = "تاريخ الاضافة")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime RecordDate { get; set; } = DateTime.Now;

        public VideoStatus VideoStatus { get; set; } = VideoStatus.UnderReview;

        // Forign Keys 
       // public int VideoCategoryId { get; set; }
       //public VideoCategory VideoCategory { get; set; }

        [StringLength(450)]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; } 
        
        public int ContributorId { get; set; }
        public Contributor Contributor { get; set; }


        public int VideoCatId { get; set; }
        public VideoCat VideoCat { get; set; }


        
    }
}



