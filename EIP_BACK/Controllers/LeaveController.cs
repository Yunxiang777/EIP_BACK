using Microsoft.AspNetCore.Mvc;
using EIP_BACK.DTOs;
using EIP_BACK.Interfaces;

namespace EIP_BACK.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaveController : ControllerBase
    {
        private readonly ILeaveFormService _service;

        public LeaveController(ILeaveFormService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateLeaveForm([FromBody] CreateLeaveFormRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.FormId) || string.IsNullOrWhiteSpace(request.ApplicantCode))
                return BadRequest("FormId 與 ApplicantCode 為必填");

            await _service.CreateLeaveFormAsync(request);
            return Ok(new { message = "請假單建立成功" });
        }
    }
}
