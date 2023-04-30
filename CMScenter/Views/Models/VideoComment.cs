using System.ComponentModel.DataAnnotations;

namespace CMScenter.Views.Models
{
    public class VideoComment
    {
        [Key]
        public int Id { get; set; }

        [StringLength(2000)]
        public string Content { get; set; }

        [Required]
        public string CommenterName { get; set; }

        public string CountryName { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public bool IsVisible { get; set; }

        [Display(Name = "تاريخ الاضافة")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime RecordDate { get; set; }


    }
}

