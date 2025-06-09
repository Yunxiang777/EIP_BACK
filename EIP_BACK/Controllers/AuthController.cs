using Microsoft.AspNetCore.Mvc;
using EIP_BACK.Interfaces;
using EIP_BACK.DTOs;
using EIP_BACK.Entities;

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
            if (string.IsNullOrWhiteSpace(request.USER_ID) || string.IsNullOrWhiteSpace(request.PASSWD))
                return BadRequest(new { message = "請提供帳號與密碼" });

            User? user = await _authService.LoginAsync(request.USER_ID, request.PASSWD);

            if (user == null)
                return Unauthorized(new { message = "帳號或密碼錯誤，或帳號未啟用" });

            // 登入成功回傳使用者資料
            var response = new UserResponse
            {
                USER_CODE = user.USER_CODE,
                USER_ID = user.USER_ID,
                USER_NAME = user.USER_NAME,
                EMAIL = user.EMAIL,
                MOBILE = user.MOBILE,
                CRDAT = user.CRDAT.ToString("yyyy年M月d號")
            };

            return Ok(response);
        }
    }
}
