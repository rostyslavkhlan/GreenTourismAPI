using AutoMapper;
using GreenTourismAPI.Domain.Security.Tokens;
using GreenTourismAPI.Domain.Services;
using GreenTourismAPI.Domain.Services.Communication.Responses;
using GreenTourismAPI.Resources;
using GreenTourismAPI.Resources.Users;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GreenTourismAPI.Controllers
{
    public class LoginController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authenticationService;

        public LoginController(IMapper mapper, IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
            _mapper = mapper;
        }

        [Route("/api/login")]
        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromBody] UserCredentialsResource userCredentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _authenticationService.CreateAccessTokenAsync(userCredentials.Email, userCredentials.Password);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            var loginResource = _mapper.Map<UserLoginResponse, LoginResource>(response);
            return Ok(loginResource);
        }

        [Route("/api/token/refresh")]
        [HttpPost]
        public async Task<IActionResult> RefreshTokenAsync([FromBody] RefreshTokenResource refreshTokenResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _authenticationService.RefreshTokenAsync(refreshTokenResource.Token, refreshTokenResource.UserEmail);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            var tokenResource = _mapper.Map<AccessToken, AccessTokenResource>(response.Token);
            return Ok(tokenResource);
        }

        [Route("/api/token/revoke")]
        [HttpPost]
        public IActionResult RevokeToken([FromBody] RevokeTokenResource revokeTokenResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _authenticationService.RevokeRefreshToken(revokeTokenResource.Token);
            return NoContent();
        }
    }
}
