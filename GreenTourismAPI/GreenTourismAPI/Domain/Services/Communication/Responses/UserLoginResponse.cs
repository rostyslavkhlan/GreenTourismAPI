using GreenTourismAPI.Domain.Models;
using GreenTourismAPI.Domain.Security.Tokens;

namespace GreenTourismAPI.Domain.Services.Communication.Responses
{
    public class UserLoginResponse : BaseResponse
    {
        public AccessToken Token { get; set; }
        public User User { get; set; }

        public UserLoginResponse(bool success, string message, AccessToken token, User user) : base(success, message)
        {
            Token = token;
            User = user;
        }
    }
}
