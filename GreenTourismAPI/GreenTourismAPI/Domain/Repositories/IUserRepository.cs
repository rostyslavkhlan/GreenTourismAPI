using GreenTourismAPI.Domain.Models;
using GreenTourismAPI.Domain.Models.Enums;
using System.Threading.Tasks;

namespace GreenTourismAPI.Domain.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user, Roles[] userRoles);
        Task<User> FindByEmailAsync(string email);
    }
}
