using AhmadProfileSmarter.dto.CollaboratedFile;
using AhmadProfileSmarter.Services.CollaboratedFiles;
using AhmadService.dto.Credentials;
using AhmadService.Services.Drive;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AhmadProfileSmarter.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CollaboratedFilesController : ControllerBase
    {
        public readonly CollaboratedFilesService _service;

        public CollaboratedFilesController(CollaboratedFilesService service)
        {
            _service = service;
        }


        [Authorize(Roles = "SuperAdmin,Admin,Moderator")]
        [HttpGet("GetFilesDocx")]
        public async Task<IActionResult> GetFilesDocx()
        {
            var res = await _service.GetFilesDocx();

            if (res == null)
                return NotFound("No Participant Docx file found");

            return Ok(res);
        }

        [Authorize(Roles = "SuperAdmin,Admin,Moderator")]
        [HttpPut("UpdateFileDoc")]
        public async Task<IActionResult> UpdateFileDoc([FromBody] CollaboratedFilesDto dto)
        {
            var res = await _service.UpdateFileDoc(dto);

            if (res == null)
                return NotFound("No Participant Docx file found");

            return Ok(res);
        }
    }
}
