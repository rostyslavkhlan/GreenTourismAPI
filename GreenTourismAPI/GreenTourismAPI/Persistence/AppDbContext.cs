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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Place>().ToTable("Places");
            modelBuilder.Entity<Place>().HasKey(p => p.Id);
            modelBuilder.Entity<Place>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Place>().Property(p => p.Title).IsRequired().HasMaxLength(30);

            modelBuilder.Entity<Place>().HasData
            (
                new Place { Id = 101, Title = "Title 1", ShortDescription = "Short Description", Thumbnail = "Thumbnail" },
                new Place { Id = 102, Title = "Title 2", ShortDescription = "Short Description", Thumbnail = "Thumbnail" }
            );
        }
    }
}
