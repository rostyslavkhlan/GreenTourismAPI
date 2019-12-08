using GreenTourismAPI.Domain.Models;
using GreenTourismAPI.Domain.Models.Enums;
using GreenTourismAPI.Domain.Repositories;
using GreenTourismAPI.Domain.Security.Hashing;
using GreenTourismAPI.Domain.Services;
using GreenTourismAPI.Domain.Services.Communication.Responses;
using System.Threading.Tasks;

namespace GreenTourismAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _UserRepository;
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IPasswordHasher _PasswordHasher;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IPasswordHasher passwordHasher)
        {
            _UserRepository = userRepository;
            _UnitOfWork = unitOfWork;
            _PasswordHasher = passwordHasher;
        }

        public async Task<CreateUserResponse> CreateUserAsync(User user, params Roles[] userRoles)
        {
            var existingUser = await _UserRepository.FindByEmailAsync(user.Email);
            if (existingUser != null)
            {
                return new CreateUserResponse("Email already in use.");
            }

            user.Password = _PasswordHasher.HashPassword(user.Password);

            await _UserRepository.AddAsync(user, userRoles);
            await _UnitOfWork.CompleteAsync();

            return new CreateUserResponse(user);
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            return await _UserRepository.FindByEmailAsync(email);
        }
    }
}
