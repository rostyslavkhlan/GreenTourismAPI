using GreenTourismAPI.Domain.Security.Tokens;

namespace GreenTourismAPI.Domain.Services.Communication.Responses
{
    public class TokenResponse : BaseResponse
    {
        public AccessToken Token { get; set; }

        public TokenResponse(bool success, string message, AccessToken token) : base(success, message)
        {
            Token = token;
        }

        public TokenResponse(AccessToken token) : this(true, string.Empty, token)
        { }

        public TokenResponse(string message) : this(false, message, null)
        { }
    }
}
