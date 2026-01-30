using DMF_Services.Models;
using Microsoft.EntityFrameworkCore;

namespace DMF_Services.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<UserDetail> UserDetails => Set<UserDetail>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserDetail>(static entity =>
            {
                entity.ToTable("UserDetail");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.Mobile)
                      .IsRequired()
                      .HasMaxLength(20);
            });
        }
    }
}
