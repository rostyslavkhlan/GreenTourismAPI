using GreenTourismAPI.Domain.Models;
using GreenTourismAPI.Domain.Security.Hashing;
using Microsoft.EntityFrameworkCore;

namespace GreenTourismAPI.Persistence
{
    public class AppDbContext : DbContext
    {
        private readonly IPasswordHasher _PasswordHasher;

        public AppDbContext(DbContextOptions<AppDbContext> options, IPasswordHasher passwordHasher) : base(options)
        {
            _PasswordHasher = passwordHasher;
        }

        public DbSet<Place> Places { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRole>().HasKey(ur => new { ur.UserId, ur.RoleId });

            #region Roles

            modelBuilder.Entity<Role>().ToTable("Roles");
            modelBuilder.Entity<Role>().HasKey(p => p.Id);
            modelBuilder.Entity<Role>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Role>().Property(p => p.Name).IsRequired().HasMaxLength(50);

            #endregion

            #region Users

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>().HasKey(p => p.Id);
            modelBuilder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().Property(p => p.FirstName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<User>().Property(p => p.LastName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<User>().Property(p => p.Email).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<User>().Property(p => p.Password).IsRequired().HasMaxLength(50);

            #endregion

            #region Places

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

            #endregion

            #region Hotels

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
                    Thumbnail = "wqrds.jpg",
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

            #endregion

            #region Facilities

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

            #endregion

            #region Rooms

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

            #endregion

            #region PlacesImages

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

            #endregion

            #region HotelsImages

            modelBuilder.Entity<HotelImage>().ToTable("HotelsImages");
            modelBuilder.Entity<HotelImage>().HasKey(i => i.Id);
            modelBuilder.Entity<HotelImage>().Property(i => i.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<HotelImage>().Property(i => i.Name).IsRequired();
            modelBuilder.Entity<HotelImage>().Property(i => i.HotelId).IsRequired();

            modelBuilder.Entity<HotelImage>().HasData
            (
                new HotelImage
                {
                    Id = 101,
                    Name = "bgfn.jpg",
                    HotelId = 101
                },
                new HotelImage
                {
                    Id = 102,
                    Name = "nbfd.jpg",
                    HotelId = 101
                },
                new HotelImage
                {
                    Id = 103,
                    Name = "qwerdf.jpg",
                    HotelId = 101
                },
                new HotelImage
                {
                    Id = 104,
                    Name = "vxcd.jpg",
                    HotelId = 101
                },
                new HotelImage
                {
                    Id = 105,
                    Name = "wqrds.jpg",
                    HotelId = 101
                }
            );

            #endregion
        }
    }
}
