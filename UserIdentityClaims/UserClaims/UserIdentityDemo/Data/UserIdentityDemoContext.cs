using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserIdentityDemo.Areas.Identity.Data;
using UserIdentityDemo.Models;

namespace UserIdentityDemo.Data
{
    public class UserIdentityDemoContext : IdentityDbContext<SampleUserData>
    {
        public UserIdentityDemoContext (DbContextOptions<UserIdentityDemoContext> options)
            : base(options)
        {
        }

        //public DbSet<Post> posts { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        //public DbSet<Post> posts { get; set; } = default!;
        public DbSet<UserIdentityDemo.Models.Post> Post { get; set; } = default!;
    }
}
