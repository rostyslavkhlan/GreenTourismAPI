using GreenTourismAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenTourismAPI.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Place> Places { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Facility> Facilities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Place>().ToTable("Places");
            modelBuilder.Entity<Place>().HasKey(p => p.Id);
            modelBuilder.Entity<Place>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Place>().Property(p => p.Title).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<Place>().HasData
            (
                new Place
                {
                    Id = 101,
                    Title = "Title 1",
                    ShortDescription = "Short Description",
                    Thumbnail = "Thumbnail"
                },
                new Place
                {
                    Id = 102,
                    Title = "Title 2",
                    ShortDescription = "Short Description",
                    Thumbnail = "Thumbnail" }
            );

            modelBuilder.Entity<Hotel>().ToTable("Hotels");
            modelBuilder.Entity<Hotel>().HasKey(h => h.Id);
            modelBuilder.Entity<Hotel>().Property(h => h.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Hotel>().Property(h => h.Title).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<Hotel>().HasData
            (
                new Hotel
                {
                    Id = 101,
                    Title = "Title 1",
                    ShortDescription = "Short Description",
                    Thumbnail = "Thumbnail",
                    PlaceId = 101
                },
                new Hotel
                {
                    Id = 102,
                    Title = "Title 2",
                    ShortDescription = "Short Description",
                    Thumbnail = "Thumbnail",
                    PlaceId = 102
                }
            );

            modelBuilder.Entity<Facility>().ToTable("Facilities");
            modelBuilder.Entity<Facility>().HasKey(h => h.Id);
            modelBuilder.Entity<Facility>().Property(h => h.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Facility>().Property(h => h.Name).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<Facility>().HasData
            (
                new Facility
                {
                    Id = 101,
                    Name = "Name 1",
                },
                new Facility
                {
                    Id = 102,
                    Name = "Name 2",
                }
            );
        }
    }
}
