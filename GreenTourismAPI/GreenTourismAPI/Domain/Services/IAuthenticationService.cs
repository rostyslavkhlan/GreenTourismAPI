using GreenTourismAPI.Domain.Services.Communication.Responses;
using System.Threading.Tasks;

namespace GreenTourismAPI.Domain.Services
{
    public interface IAuthenticationService
    {
        Task<UserLoginResponse> CreateAccessTokenAsync(string email, string password);
        Task<TokenResponse> RefreshTokenAsync(string refreshToken, string userEmail);
        void RevokeRefreshToken(string refreshToken);
    }
}
