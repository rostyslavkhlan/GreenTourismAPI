using GreenTourismAPI.Domain.Models;

namespace GreenTourismAPI.Domain.Services.Communication.Responses
{
    public class CreateUserResponse : BaseResponse
    {
        public User User { get; private set; }

        public CreateUserResponse(bool success, string message, User user) : base(success, message)
        {
            User = user;
        }

        public CreateUserResponse(string message) : this(false, message, null)
        {
        }

        public CreateUserResponse(User user) : this(true, string.Empty, user)
        {
        }
    }
}
