using GreenTourismAPI.Domain.Models;
using GreenTourismAPI.Domain.Models.Enums;
using GreenTourismAPI.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GreenTourismAPI.Persistence.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(User user, Roles[] userRoles)
        {
            var roles = await context.Roles.Where(r => userRoles.Any(ur => ur.ToString() == r.Name)).ToListAsync();

            foreach (var role in roles)
            {
                user.UserRoles.Add(new UserRole { RoleId = role.Id });
            }

            context.Users.Add(user);
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            return await context.Users.Include(u => u.UserRoles)
                                       .ThenInclude(ur => ur.Role)
                                       .SingleOrDefaultAsync(u => u.Email == email);
        }
    }
}
