using AhmadService.dto.Attachment;
using AhmadService.dto.EmployeeFile;
using AhmadService.dto.ParticipantFile;
using AhmadService.dto.PersonalFile;
using AhmadService.Services.Drive;
using AhmadService.Services.Employees;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AhmadAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DriveController : ControllerBase
    {
        public readonly DriveService _service;

        public DriveController(DriveService service)
        {
            _service = service;
        }

        [HttpGet("GetAllParticipantsFiles")]
        public async Task<IActionResult> GetAllParticipantsFiles()
        {
            var res = await _service.GetAllParticipantsFiles();

            if(res == null)
                return NotFound();

            return Ok(res);
        }

        [HttpPost("SaveParticipantFile")]
        public async Task<IActionResult> SaveParticipantFile([FromForm] ParticipantFileDto model)
        {
            if (model.File == null || model.File.Length == 0)
                return BadRequest("File is required");

            using var memoryStream = new MemoryStream();
            await model.File.CopyToAsync(memoryStream);

            var fileBytes = memoryStream.ToArray();

            var result = await _service.SaveParticipantFile(
                model.File.FileName,
                fileBytes,
                model.File.Length.ToString(),
                DateTime.Now
            );

            if (result)
                return Ok(true);

            return BadRequest(false);
        }

        [HttpGet("GetAllPersonalFiles")]
        public async Task<IActionResult> GetAllPersonalFiles()
        {
            var res = await _service.GetAllPersonalFiles();

            if (res == null)
                return NotFound();

            return Ok(res);
        }

        [HttpPost("SavePersonalFile")]
        public async Task<IActionResult> SavePersonalFile([FromForm] PersonalFileDto model)
        {
            if (model.File == null || model.File.Length == 0)
                return BadRequest("File is required");

            using var memoryStream = new MemoryStream();
            await model.File.CopyToAsync(memoryStream);

            var fileBytes = memoryStream.ToArray();

            var result = await _service.SavePersonalFile(
                model.File.FileName,
                fileBytes,
                model.File.Length.ToString(),
                DateTime.Now
            );

            if (result)
                return Ok(true);

            return BadRequest(false);
        }

        [HttpGet("GetAllEmployeeFiles")]
        public async Task<IActionResult> GetAllEmployeeFiles()
        {
            var res = await _service.GetAllEmployeeFiles();

            if (res == null)
                return NotFound();

            return Ok(res);
        }

        [HttpPost("SaveEmployeeFiles")]
        public async Task<IActionResult> SaveEmployeeFiles([FromForm] EmployeeFileDto model)
        {
            if (model.File == null || model.File.Length == 0)
                return BadRequest("File is required");

            using var memoryStream = new MemoryStream();
            await model.File.CopyToAsync(memoryStream);

            var fileBytes = memoryStream.ToArray();

            var result = await _service.SaveEmployeeFiles(
                model.File.FileName,
                fileBytes,
                model.File.Length.ToString(),
                DateTime.Now
            );

            if (result)
                return Ok(true);

            return BadRequest(false);
        }
    }
}
