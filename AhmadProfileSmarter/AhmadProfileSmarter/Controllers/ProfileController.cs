using AhmadService.dto.ChangePassword;
using AhmadService.Services.Employees;
using AhmadService.Services.Profile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AhmadAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : ControllerBase
    {
        public readonly ProfileService _service;

        public ProfileController(ProfileService service)
        {
            _service = service;
        }

        [HttpGet("GetAllNotificationofReciever/{receiverId}")]
        public async Task<IActionResult> GetAllNotificationofReciever(int receiverId)
        {
            var notifications = await _service.GetAllNotificationofReciever(receiverId);

            if (notifications == null || notifications.Count == 0)
            {
                return Ok("No notifications found for this user.");
            }

            return Ok(notifications);
        }

        [HttpGet("MarkNotificationRead/{id}")]
        public async Task<IActionResult> MarkNotificationRead(int id)
        {
            var read = await _service.MarkNotificationRead(id);

            if(read==false)
            {
                return NotFound(read);
            }

            return Ok(read);
        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto model)
        {
            var result = await _service.ChangePassword(model.userid,model.pass);

            if (!result)
                return NotFound("User not found");

            return Ok("Password changed successfully");
        }
    }
}
