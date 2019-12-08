using GreenTourismAPI.Domain.Models;
using GreenTourismAPI.Domain.Models.Enums;
using GreenTourismAPI.Domain.Services.Communication.Responses;
using System.Threading.Tasks;

namespace GreenTourismAPI.Domain.Services
{
    public interface IUserService
    {
        Task<CreateUserResponse> CreateUserAsync(User user, params Roles[] userRoles);
        Task<User> FindByEmailAsync(string email);
    }
}
