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

        public DbSet<PlaceImage> PlacesImages { get; set; }
        public DbSet<HotelImage> HotelsImages { get; set; }

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

            #endregion

            #region Hotels

            modelBuilder.Entity<Hotel>().ToTable("Hotels");
            modelBuilder.Entity<Hotel>().HasKey(h => h.Id);
            modelBuilder.Entity<Hotel>().Property(h => h.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Hotel>().Property(h => h.Title).IsRequired().HasMaxLength(50);

            #endregion

            #region Facilities

            modelBuilder.Entity<Facility>().ToTable("Facilities");
            modelBuilder.Entity<Facility>().HasKey(h => h.Id);
            modelBuilder.Entity<Facility>().Property(h => h.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Facility>().Property(h => h.Name).IsRequired().HasMaxLength(50);

            #endregion

            #region Rooms

            modelBuilder.Entity<Room>().ToTable("Rooms");
            modelBuilder.Entity<Room>().HasKey(r => r.Id);
            modelBuilder.Entity<Room>().Property(r => r.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Room>().Property(r => r.Title).IsRequired().HasMaxLength(50);

            #endregion

            #region PlacesImages

            modelBuilder.Entity<PlaceImage>().ToTable("PlacesImages");
            modelBuilder.Entity<PlaceImage>().HasKey(i => i.Id);
            modelBuilder.Entity<PlaceImage>().Property(i => i.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<PlaceImage>().Property(i => i.Name).IsRequired();
            modelBuilder.Entity<PlaceImage>().Property(i => i.PlaceId).IsRequired();

            #endregion

            #region HotelsImages

            modelBuilder.Entity<HotelImage>().ToTable("HotelsImages");
            modelBuilder.Entity<HotelImage>().HasKey(i => i.Id);
            modelBuilder.Entity<HotelImage>().Property(i => i.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<HotelImage>().Property(i => i.Name).IsRequired();
            modelBuilder.Entity<HotelImage>().Property(i => i.HotelId).IsRequired();

            #endregion
        }
    }
}
