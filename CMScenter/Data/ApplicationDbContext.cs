using CMScenter.Views.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CMScenter.Data
{
    public class ApplicationDbContext :IdentityDbContext 
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }

        // CMScenter project databaser 
        public DbSet<AppSittings> AppSittings { get; set; }
        public DbSet<CourseCategory> CourseCategories { get; set; }
        public DbSet<Services> Services { get; set; }
        
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<Partners> Partners { get; set; }
        public DbSet<Posts> Posts { get; set; }
        public DbSet<PostsCategory > PostsCategories { get; set; }
        public DbSet<SubmenuBox > SubmenuBoxes { get; set; }

        // Nourgram project database 

        public DbSet<Video> Videos { get; set; }
        
        public DbSet<VideoComment> VideoComments { get; set; }
        public DbSet<Contributor> Contributors { get; set; }
     public DbSet<VideoCat> VideoCats { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
