using System.ComponentModel.DataAnnotations;

namespace GreenTourismAPI.Resources.Users
{
    public class RevokeTokenResource
    {
        [Required]
        public string Token { get; set; }
    }
}
