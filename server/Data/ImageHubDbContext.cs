using Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ImageHubDbContext : IdentityDbContext<ImageHubUser, UserRole, int>
    {
        public ImageHubDbContext()
        {
        }

        public DbSet<ImageHubUser> Users { get; set; }

        public DbSet<ImagehubImage> Images { get; set; }

        public ImageHubDbContext(DbContextOptions<ImageHubDbContext> opts)
            : base(opts)
        {
            this.Database.EnsureCreated();
        }

                
    }
}
