using GreenTourismAPI.Domain.Models;
using GreenTourismAPI.Domain.Models.Enums;
using GreenTourismAPI.Domain.Security.Hashing;
using System.Collections.Generic;
using System.Linq;

namespace GreenTourismAPI.Persistence
{
    public class DatabaseSeed
    {
        public static void Seed(AppDbContext context, IPasswordHasher passwordHasher)
        {
            context.Database.EnsureCreated();

            SeedPlaces(context);
            SeedHotels(context);

            SeedFacilities(context);
            SeedRooms(context);

            SeedRoles(context);
            SeedUsers(context, passwordHasher);

            SeedPlaceImages(context);
            SeedHotelImages(context);
        }

        private static void SeedRoles(AppDbContext context)
        {
            if (context.Roles.Count() == 0)
            {

                var roles = new List<Role>
                {
                new Role { Name = Roles.Common.ToString() },
                new Role { Name = Roles.Administrator.ToString() }
                };

                context.Roles.AddRange(roles);
                context.SaveChanges();
            }
        }

        private static void SeedUsers(AppDbContext context, IPasswordHasher passwordHasher)
        {
            if (context.Users.Count() == 0)
            {
                var users = new List<User>
                {
                    new User
                    {
                        FirstName = "Admin",
                        LastName = "Admin",
                        Email = "admin@admin.com",
                        Password = passwordHasher.HashPassword("12345678")
                    },
                    new User
                    {
                        FirstName = "Common",
                        LastName = "User",
                        Email = "common@common.com",
                        Password = passwordHasher.HashPassword("12345678")
                    }
                };

                users[0].UserRoles.Add(new UserRole
                {
                    RoleId = context.Roles.SingleOrDefault(r => r.Name == Roles.Administrator.ToString()).Id
                });

                users[1].UserRoles.Add(new UserRole
                {
                    RoleId = context.Roles.SingleOrDefault(r => r.Name == Roles.Common.ToString()).Id
                });

                context.Users.AddRange(users);
                context.SaveChanges();
            }
        }

        private static void SeedPlaces(AppDbContext context)
        {
            if (context.Places.Count() == 0)
            {
                var places = new List<Place>
                {
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
                };

                context.Places.AddRange(places);
                context.SaveChanges();
            }
        }

        private static void SeedHotels(AppDbContext context)
        {
            if (context.Hotels.Count() == 0)
            {
                var hotels = new List<Hotel>
                {
                    new Hotel
                    {
                        Id = 101,
                        Title = "Title 1",
                        Address = "Address 1",
                        ShortDescription = "Short Description 1",
                        LongDescription = "Long Description 1",
                        Thumbnail = "wqrds.jpg",
                        PlaceId = 101
                    },
                    new Hotel
                    {
                        Id = 102,
                        Title = "Title 2",
                        Address = "Address 2",
                        ShortDescription = "Short Description 2",
                        LongDescription = "Long Description 2",
                        Thumbnail = "153005888.jpg",
                        PlaceId = 102
                    }
                };

                context.Hotels.AddRange(hotels);
                context.SaveChanges();
            }
        }

        private static void SeedFacilities(AppDbContext context)
        {
            if (context.Facilities.Count() == 0)
            {
                var facilities = new List<Facility>
                {
                    new Facility { Name = "TV" },
                    new Facility { Name = "Free WiFi" },
                    new Facility { Name = "Private bathroom" },
                    new Facility { Name = "Sofa" }
                };

                context.Facilities.AddRange(facilities);
                context.SaveChanges();
            }
        }

        private static void SeedRooms(AppDbContext context)
        {
            if (context.Rooms.Count() == 0)
            {
                var rooms = new List<Room>
                {
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
                };

                rooms[0].RoomFacilities.Add( new RoomFacility
                {
                    FacilityId = context.Facilities.FirstOrDefault(f => f.Name.Equals("TV")).Id
                });
                rooms[0].RoomFacilities.Add(new RoomFacility
                {
                    FacilityId = context.Facilities.FirstOrDefault(f => f.Name.Equals("Free WiFi")).Id
                });
                rooms[0].RoomFacilities.Add(new RoomFacility
                {
                    FacilityId = context.Facilities.FirstOrDefault(f => f.Name.Equals("Private bathroom")).Id
                });

                rooms[1].RoomFacilities.Add(new RoomFacility
                {
                    FacilityId = context.Facilities.FirstOrDefault(f => f.Name.Equals("TV")).Id
                });
                rooms[1].RoomFacilities.Add(new RoomFacility
                {
                    FacilityId = context.Facilities.FirstOrDefault(f => f.Name.Equals("Private bathroom")).Id
                });
                rooms[1].RoomFacilities.Add(new RoomFacility
                {
                    FacilityId = context.Facilities.FirstOrDefault(f => f.Name.Equals("Sofa")).Id
                });

                context.Rooms.AddRange(rooms);
                context.SaveChanges();
            }
        }

        private static void SeedPlaceImages(AppDbContext context)
        {
            if (context.PlacesImages.Count() == 0)
            {
                var placeImages = new List<PlaceImage>
                {
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
                };

                context.PlacesImages.AddRange(placeImages);
                context.SaveChanges();
            }
        }

        private static void SeedHotelImages(AppDbContext context)
        {
            if (context.HotelsImages.Count() == 0)
            {
                var hotelsImages = new List<HotelImage>
                {
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
                    },
                    new HotelImage
                    {
                        Id = 106,
                        Name = "148615986.jpg",
                        HotelId = 102
                    },
                    new HotelImage
                    {
                        Id = 107,
                        Name = "150066534.jpg",
                        HotelId = 102
                    },
                    new HotelImage
                    {
                        Id = 108,
                        Name = "150066552.jpg",
                        HotelId = 102
                    },
                    new HotelImage
                    {
                        Id = 109,
                        Name = "153005888.jpg",
                        HotelId = 102
                    },
                };

                context.HotelsImages.AddRange(hotelsImages);
                context.SaveChanges();
            }
        }
    }
}
