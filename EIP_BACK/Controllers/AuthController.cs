using Microsoft.AspNetCore.Mvc;
using EIP_BACK.Interfaces;
using EIP_BACK.DTOs;

namespace EIP_BACK.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.UserId) || string.IsNullOrWhiteSpace(request.Password))
                return BadRequest(new { message = "請提供帳號與密碼" });

            bool isValid = await _authService.LoginAsync(request.UserId, request.Password);

            if (isValid)
                return Ok(new { message = "登入成功" });

            return Unauthorized(new { message = "帳號或密碼錯誤，或帳號未啟用" });
        }
    }
}
