using AutoMapper;
using GreenTourismAPI.Domain.Models;
using GreenTourismAPI.Domain.Models.Enums;
using GreenTourismAPI.Domain.Services;
using GreenTourismAPI.Resources.Users;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GreenTourismAPI.Controllers
{
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("api/register")]
        public async Task<IActionResult> CreateUserAsync([FromBody] UserRegisterResource userCredentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _mapper.Map<UserRegisterResource, User>(userCredentials);

            var response = await _userService.CreateUserAsync(user, Roles.Common);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            var userResource = _mapper.Map<User, UserResource>(response.User);
            return Ok(userResource);
        }
    }
}
