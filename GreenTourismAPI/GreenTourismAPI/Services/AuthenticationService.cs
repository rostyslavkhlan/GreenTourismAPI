using GreenTourismAPI.Domain.Security.Hashing;
using GreenTourismAPI.Domain.Security.Tokens;
using GreenTourismAPI.Domain.Services;
using GreenTourismAPI.Domain.Services.Communication.Responses;
using System.Threading.Tasks;

namespace GreenTourismAPI.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserService _userService;
        private readonly IPasswordHasher _PasswordHasher;
        private readonly ITokenHandler _TokenHandler;

        public AuthenticationService(IUserService userService, IPasswordHasher passwordHasher, ITokenHandler tokenHandler)
        {
            _userService = userService;
            _PasswordHasher = passwordHasher;
            _TokenHandler = tokenHandler;
        }

        public async Task<TokenResponse> CreateAccessTokenAsync(string email, string password)
        {
            var user = await _userService.FindByEmailAsync(email);

            if (user == null || !_PasswordHasher.PasswordMatches(password, user.Password))
            {
                return new TokenResponse("Invalid credentials.");
            }

            var token = _TokenHandler.CreateAccessToken(user);

            return new TokenResponse(token);
        }

        public async Task<TokenResponse> RefreshTokenAsync(string refreshToken, string userEmail)
        {
            var token = _TokenHandler.TakeRefreshToken(refreshToken);

            if (token == null)
            {
                return new TokenResponse("Invalid refresh token.");
            }

            if (token.IsExpired())
            {
                return new TokenResponse("Expired refresh token.");
            }

            var user = await _userService.FindByEmailAsync(userEmail);
            if (user == null)
            {
                return new TokenResponse("Invalid refresh token.");
            }

            var accessToken = _TokenHandler.CreateAccessToken(user);
            return new TokenResponse(accessToken);
        }

        public void RevokeRefreshToken(string refreshToken)
        {
            _TokenHandler.RevokeRefreshToken(refreshToken);
        }
    }
}
