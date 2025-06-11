using Microsoft.AspNetCore.Mvc;
using EIP_BACK.Interfaces;

namespace EIP_BACK.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkTimeController : ControllerBase
    {
        private readonly IWorkTimeService _iworkTimeService;

        public WorkTimeController(IWorkTimeService workTimeService)
        {
            _iworkTimeService = workTimeService;
        }

        [HttpGet("{userCode}")]
        public async Task<IActionResult> GetByUserCode(string userCode)
        {
            if (string.IsNullOrWhiteSpace(userCode))
                return BadRequest(new { message = "USER_CODE 不可為空" });

            var result = await _iworkTimeService.GetWorkTimesByUserCodeAsync(userCode);

            if (result == null || !result.Any())
                return NotFound(new { message = "找不到排班資料" });

            return Ok(result);
        }
    }
}
