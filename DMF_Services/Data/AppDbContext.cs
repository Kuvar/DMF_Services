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
        public DbSet<CarDetail> CarDetails => Set<CarDetail>();
        public DbSet<CarImage> CarImages => Set<CarImage>();

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

            modelBuilder.Entity<CarDetail>(entity =>
            {
                entity.ToTable("CarDetail");
                entity.HasKey(x => x.Id);

                entity.HasOne(x => x.CarImage)
                      .WithOne(x => x.CarDetail)
                      .HasForeignKey<CarImage>(x => x.CarDetailID);
            });

            modelBuilder.Entity<CarImage>(entity =>
            {
                entity.ToTable("CarImage");
                entity.HasKey(x => x.Id);
            });

            modelBuilder.Entity<CarFilterRaw>().HasNoKey();
            modelBuilder.Entity<CarBrandRaw>().HasNoKey();
            modelBuilder.Entity<CarModelRaw>().HasNoKey();
        }
    }
}
