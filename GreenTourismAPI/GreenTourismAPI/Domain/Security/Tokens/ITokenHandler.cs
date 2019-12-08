using GreenTourismAPI.Domain.Models;

namespace GreenTourismAPI.Domain.Security.Tokens
{
    public interface ITokenHandler
    {
        AccessToken CreateAccessToken(User user);
        RefreshToken TakeRefreshToken(string token);
        void RevokeRefreshToken(string token);
    }
}
