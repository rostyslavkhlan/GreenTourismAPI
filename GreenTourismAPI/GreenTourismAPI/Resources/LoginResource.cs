using GreenTourismAPI.Resources.Users;

namespace GreenTourismAPI.Resources
{
    public class LoginResource
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public long Expiration { get; set; }
        public UserResource User { get; set; }
    }
}
