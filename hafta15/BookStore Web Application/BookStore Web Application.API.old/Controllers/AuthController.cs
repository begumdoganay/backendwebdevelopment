using BookStore_Web_Application.Core.Dtos.Authentication;
using BookStore_Web_Application.Core.Interfaces.Authentication;
using IdentityModel.Client;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RefreshTokenRequest = BookStore_Web_Application.Core.Dtos.Authentication.RefreshTokenRequest;

namespace BookStore_Web_Application.API.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IIdentityService _identityService;

        public AuthController(IMediator mediator, IIdentityService identityService)
            : base(mediator)
        {
            _identityService = identityService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthenticationResult>> Login(LoginDto loginDto)
        {
            if (string.IsNullOrEmpty(loginDto.Email) || string.IsNullOrEmpty(loginDto.Password))
            {
                return BadRequest("Email and password are required.");
            }

            var result = await _identityService.LoginAsync(loginDto.Email, loginDto.Password);
            return Ok(result);
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<AuthenticationResult>> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            if (string.IsNullOrEmpty(request.RefreshToken))
            {
                return BadRequest("Refresh token is required.");
            }

            var result = await _identityService.RefreshTokenAsync(request.RefreshToken);
            return Ok(result);
        }

        [HttpPost("revoke-token")]
        [Authorize]
        public async Task<IActionResult> RevokeToken([FromBody] RevokeTokenRequest request)
        {
            if (string.IsNullOrEmpty(request.RefreshToken))
            {
                return BadRequest("Refresh token is required.");
            }

            await _identityService.RevokeTokenAsync(request.RefreshToken);
            return Ok();
        }
    }
}
