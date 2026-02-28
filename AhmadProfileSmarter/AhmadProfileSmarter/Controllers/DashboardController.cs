using AhmadService.Services.Dashboard;
using AhmadService.Services.Register;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AhmadAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        public readonly DashboardService _service;

        public DashboardController(DashboardService service)
        {
            _service = service;
        }

        [HttpGet("GetAllMeetings")]
        public async Task<IActionResult> GetAllMeetings()
        {
            var result = await _service.GetAllMeetings();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("GetTotalParticipants")]
        public async Task<IActionResult> GetTotalParticipants()
        {
            var result = await _service.GetTotalParticipants();

            return Ok(result);
        }

        [HttpGet("GetActiveParticipants")]
        public async Task<IActionResult> GetActiveParticipants()
        {
            var result = await _service.GetActiveParticipants();

            return Ok(result);
        }

        [HttpGet("GetInActiveParticipants")]
        public async Task<IActionResult> GetInActiveParticipants()
        {
            var result = await _service.GetInActiveParticipants();

            return Ok(result);
        }

        [HttpGet("GetCompletedTasksCount")]
        public async Task<IActionResult> GetCompletedTasksCount()
        {
            var result = await _service.GetCompletedTasksCount();

            return Ok(result);
        }

        [HttpGet("GetActivityforDashboard")]
        public async Task<IActionResult> GetActivityforDashboard()
        {
            var result = await _service.GetActivityforDashboard();

            return Ok(result);
        }

    }
}
