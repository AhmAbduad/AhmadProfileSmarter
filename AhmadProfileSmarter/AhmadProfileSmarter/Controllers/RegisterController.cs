using AhmadService.dto.Register;
using AhmadService.Services.MeetingsVideo;
using AhmadService.Services.Register;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AhmadAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegisterController : ControllerBase
    {
        public readonly RegisterService _service;

        public RegisterController(RegisterService service)
        {
            _service = service;
        }

        [HttpGet("GetUsernameandEmail")]
        public async Task<IActionResult> GetUsernameandEmail()
        {
            var result = await _service.GetUsernameandEmail();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterDto model)
        {
            var result = await _service.RegisterUser(model);

            if(result==false)
            {
                return Ok(false);
            }
            return Ok(true);
        }
    }
}
