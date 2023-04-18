using System.Drawing.Printing;

namespace CMScenter.Views.Models
{
    public class ViewModel
    {
        public AppSittings appSettings { get; set; }
     
        public List<TeamMember> TeamMember { get; set; }
        public List<Services> services { get; set; }
        public List<SubmenuBox> subMenu { get; set; }
       public List<Posts> posts { get; set; }
    }
}
