using AhmadDAL.DataAccessLayer.Credentials;
using AhmadService.dto.Credentials;
using AhmadService.Services.Credentials;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AhmadAPI.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        public readonly LoginService _LoginService;
        public LoginController(LoginService login) { 
            _LoginService = login;
        }


        [HttpPost("CheckUser")]
        public async Task<IActionResult> CheckUser([FromBody] LoginDto loginDto)
        {
            if (string.IsNullOrEmpty(loginDto.Email) || string.IsNullOrEmpty(loginDto.Password))
                return BadRequest();

            var check = await _LoginService.ValidateUserCredential(loginDto);

            if (check == null)
                return Unauthorized("Invalid Email or Password");

            return Ok(check);
        }

    }
}
