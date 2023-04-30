using System.ComponentModel.DataAnnotations;

namespace CMScenter.Views.Models
{
    public class VideoCat
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Arabic Name")]
        [StringLength(100)]
        public string ArName { get; set; }

        [Required]
        [Display(Name = "English Name")]
        [StringLength(100)]
        public string EnName { get; set; }

        [Display(Name = "Arabic Description")]
        [StringLength(1000)]
        public string ArDescription { get; set; }

        [Display(Name = "English Description")]
        [StringLength(1000)]
        public string EnDescription { get; set; }

      
        public string Icon { get; set; }
    }
}
