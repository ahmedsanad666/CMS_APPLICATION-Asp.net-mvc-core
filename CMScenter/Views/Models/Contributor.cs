using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using static CMScenter.Views.Models.Common;

namespace CMScenter.Views.Models
{
    public class Contributor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Arabic Name")]
        public string ArName { get; set; }

        [Display(Name = "English Name")]
        public string EnName { get; set; }

        public ContributorStatus ContributorStatus { get; set; } = ContributorStatus.UnderReview;

        [StringLength(2000)]
        public string Biography { get; set; }

      
        public string ProfileImage { get; set; }

        [StringLength(50)]
        public string Website { get; set; }

        // check out cms coutry file
        public int CountryId { get; set; }

        [Display(Name = "Suggested By")]
        [StringLength(450)]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [Display(Name = "Approved By")]
        [StringLength(450)]
        public string ApprovedByUserId { get; set; }
        public ApplicationUser ApprovedByUser { get; set; }




    }
}



