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

        public DbSet<AppSittings> AppSittings { get; set; }
        public DbSet<CourseCategory> CourseCategories { get; set; }
        public DbSet<Services> Services { get; set; }
        
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<Partners> partners { get; set; }
        public DbSet<Posts> posts { get; set; }
        public DbSet<PostsCategory > postsCategories { get; set; }
        public DbSet<SubmenuBox > submenuBoxes { get; set; }
         


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
