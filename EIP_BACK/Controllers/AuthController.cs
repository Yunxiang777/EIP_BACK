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
                return BadRequest(new { message = "�д��ѱb���P�K�X" });

            User? user = await _authService.LoginAsync(request.USER_ID, request.PASSWD);

            if (user == null)
                return Unauthorized(new { message = "�b���αK�X���~�A�αb�����ҥ�" });

            // �n�J���\�^�ǨϥΪ̸��
            var response = new UserResponse
            {
                USER_CODE = user.USER_CODE,
                USER_ID = user.USER_ID,
                USER_NAME = user.USER_NAME,
                EMAIL = user.EMAIL,
                MOBILE = user.MOBILE
            };

            return Ok(response);
        }
    }
}
