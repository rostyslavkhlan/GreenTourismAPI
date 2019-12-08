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

            if (context.Users.Count() == 0)
            {
                var users = new List<User>
                {
                    new User { Email = "admin@admin.com", Password = passwordHasher.HashPassword("12345678") },
                    new User { Email = "common@common.com", Password = passwordHasher.HashPassword("12345678") },
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
    }
}
