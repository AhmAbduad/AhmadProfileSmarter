//using AhmadDAL.Models.AdminRequests;
using AhmadProfileSmarter.dto.ChangeRole;
using AhmadService.dto.AdminRequests;
using AhmadService.Services.AdminRequests;
using AhmadService.Services.Dashboard;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AhmadAPI.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AdminRequestsController : ControllerBase
    {

        public readonly AdminRequestsService _service;

        public AdminRequestsController(AdminRequestsService service)
        {
            _service = service;
        }

        //[Authorize(Roles = "SuperAdmin")]
        //[HttpPost("CreateRequest")]
        //public async Task<IActionResult> CreateRequest([FromBody] CreateRequestDto dto)
        //{
            

        //    var result = await _service.CreateRequest(dto);

        //    if(result==null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(result);
        //}

        //[Authorize(Roles = "SuperAdmin")]
        //[HttpGet("GetAdminRequestonID/{id}")]
        //public async Task<IActionResult> GetAdminRequestonID(int id)
        //{
        //    var result = await _service.GetAdminRequestonID(id);

        //    if(result==null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(result);
        //}
            

        [Authorize(Roles = "SuperAdmin")]
        [HttpGet("FetchUsers")]
        public async Task<IActionResult> FetchUsers()
        {
            var result = await _service.FetchUsers();

            if(result==null)
            {
                return NotFound();
            }

            return Ok(result);
        }


        [Authorize(Roles = "SuperAdmin")]
        [HttpGet("FetchRoles")]
        public async Task<IActionResult> FetchRoles()
        {
            var result = await _service.FetchRoles();

            if(result==null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpPut("ChangeRole/{userId}")]
        public async Task<IActionResult> ChangeRole(int userId, ChangeRoleDto dto)
        {
            var user = await _service.ChangeRole(userId, dto);

            if (user == null)
            {
                return NotFound();
            }
            

            return Ok(user);
        }
    }
}
