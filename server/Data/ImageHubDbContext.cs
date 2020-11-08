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


        public DbSet<ImagehubImage> Images { get; set; }

        public DbSet<FriendRequest> FriendRequests { get; set; }

        public DbSet<Friend> Friends{ get; set; }

        public ImageHubDbContext(DbContextOptions<ImageHubDbContext> opts)
            : base(opts)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<FriendRequest>()
                .HasOne(e => e.From)
                .WithMany(e => e.RequestsReceived)
                .HasForeignKey(e => e.FromId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<FriendRequest>()
                 .HasOne(e => e.To)
                 .WithMany(e => e.RequestsSent)
                 .HasForeignKey(e => e.ToId)
                 .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Friend>()
                .HasOne(e => e.Left)
                .WithMany(e => e.FriendshipsInitiatedList)
                .HasForeignKey(e => e.LeftId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Friend>()
                 .HasOne(e => e.Right)
                 .WithMany(e => e.FriendshipsReceivedList)
                 .HasForeignKey(e => e.RightId)
                 .OnDelete(DeleteBehavior.NoAction);
        }

    }
}
