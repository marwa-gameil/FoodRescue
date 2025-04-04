using FoodRescue.Application.DTOs;
using FoodRescue.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodRescue.API.Controllers
{
    public class AuthController :ApiBaseController
    {
        private readonly ICookieAuthService _authService;
        public AuthController(ICookieAuthService authService)
            => _authService = authService;

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginDTO loginDTO) =>
            HandleResult(await _authService.LoginAsync(loginDTO));

        [HttpPost("logout")]
        public async Task<ActionResult> Logout() =>
            HandleResult(await _authService.LogoutAsync());

        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register([FromForm] RegisterDto registerDto)
        {
            return HandleResult(await _authService.RegisterAsync(registerDto));
        }

    }
}
