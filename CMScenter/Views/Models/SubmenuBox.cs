using System.ComponentModel.DataAnnotations;

namespace CMScenter.Views.Models
{
    public class SubmenuBox
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name="SubMenu Title arabic")]
        public string arName  { get; set; }
        [Required]
        [Display(Name="SubMenu Title english")]
        public string enName  { get; set; }

        [Required]
        [Display(Name = "SubMenu1 item arabic")]
        public string arsubItem1 { get; set; }
        [Required]
        [Display(Name = "SubMenu1 item english")]
        public string enarsubItem1 { get; set; }
        [Required]
        [Display(Name = "SubMenu2 item arabic")]
        public string arsubItem2 { get; set; }
        [Required]
        [Display(Name = "SubMenu2 item english")]
        public string ensubItem2 { get; set; }
        [Required]
        [Display(Name = "SubMenu3 item arabic")]
        public string arsubItem3 { get; set; }
        [Required]
        [Display(Name = "SubMenu3 item english")]
        public string ensubItem3 { get; set; }

    }
}
