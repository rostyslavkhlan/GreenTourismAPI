using GreenTourismAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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
        public DbSet<Room> Rooms { get; set; }

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
                    Thumbnail = "ccdefa.jpg"
                },
                new Place
                {
                    Id = 102,
                    Title = "Title 2",
                    ShortDescription = "Short Description",
                    Thumbnail = "Thumbnail"
                }
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

            modelBuilder.Entity<Room>().ToTable("Rooms");
            modelBuilder.Entity<Room>().HasKey(r => r.Id);
            modelBuilder.Entity<Room>().Property(r => r.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Room>().Property(r => r.Title).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<Room>().HasData
            (
                new Room
                {
                    Id = 101,
                    Title = "Title 1",
                    Description = "Description",
                    PeopleCount = 4,
                    Price = 500,
                    Thumbnail = "Thumbnail",
                    HotelId = 101,
                },
                new Room
                {
                    Id = 102,
                    Title = "Title 2",
                    Description = "Description",
                    PeopleCount = 3,
                    Price = 700,
                    Thumbnail = "Thumbnail",
                    HotelId = 102,
                }
            );

            modelBuilder.Entity<PlaceImage>().ToTable("PlacesImages");
            modelBuilder.Entity<PlaceImage>().HasKey(i => i.Id);
            modelBuilder.Entity<PlaceImage>().Property(i => i.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<PlaceImage>().Property(i => i.Name).IsRequired();
            modelBuilder.Entity<PlaceImage>().Property(i => i.PlaceId).IsRequired();

            modelBuilder.Entity<PlaceImage>().HasData
            (
                new PlaceImage
                {
                    Id = 101,
                    Name = "ccdefa.jpg",
                    PlaceId = 101
                },
                new PlaceImage
                {
                    Id = 102,
                    Name = "cxcvcvgf.jpg",
                    PlaceId = 101
                },
                new PlaceImage
                {
                    Id = 103,
                    Name = "cxcxfe.jpg",
                    PlaceId = 101
                },
                new PlaceImage
                {
                    Id = 104,
                    Name = "zxcvba.jpg",
                    PlaceId = 101
                }
            );
            /*modelBuilder.Entity<RoomFacility>().HasKey(x => new { x.RoomId, x.FacilityId });
            modelBuilder.Entity<RoomFacility>()
                .HasOne(bc => bc.Room)
                .WithMany(b => b.RoomFacilities)
                .HasForeignKey(bc => bc.RoomId);
            modelBuilder.Entity<RoomFacility>()
                .HasOne(bc => bc.Facility)
                .WithMany(c => c.RoomFacilities)
                .HasForeignKey(bc => bc.FacilityId);*/
        }
    }
}
