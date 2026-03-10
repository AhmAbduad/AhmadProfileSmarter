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
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DriveController : ControllerBase
    {
        public readonly DriveService _service;

        public DriveController(DriveService service)
        {
            _service = service;
        }

        [Authorize(Roles = "SuperAdmin,Admin,Moderator")]
        [HttpGet("GetAllParticipantsFiles")]
        public async Task<IActionResult> GetAllParticipantsFiles(int userId)
        {
            var res = await _service.GetAllParticipantsFiles(userId);

            if(res == null)
                return NotFound("No Participant Files found");

            return Ok(res);
        }

        [Authorize(Roles = "SuperAdmin,Admin,Moderator")]
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
                DateTime.Now,
                model.UserID,
                model.File.ContentType
            );

            if (result)
                return Ok(true);

            return BadRequest(false);
        }

        [Authorize(Roles = "SuperAdmin,Admin,Moderator")]
        [HttpGet("GetAllPersonalFiles")]
        public async Task<IActionResult> GetAllPersonalFiles(int userId)
        {
            var res = await _service.GetAllPersonalFiles(userId);

            if (res == null)
                return NotFound("No Personal File found");

            return Ok(res);
        }

        [Authorize(Roles = "SuperAdmin,Admin,Moderator")]
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
                DateTime.Now,
                model.UserID,
                model.File.ContentType
            );

            if (result)
                return Ok(true);

            return BadRequest(false);
        }

        [Authorize(Roles = "SuperAdmin,Admin,Moderator")]
        [HttpGet("GetAllEmployeeFiles")]
        public async Task<IActionResult> GetAllEmployeeFiles(int userId)
        {
            var res = await _service.GetAllEmployeeFiles(userId);

            if (res == null)
                return NotFound("No Employee File found");

            return Ok(res);
        }

        [Authorize(Roles = "SuperAdmin,Admin,Moderator")]
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
                DateTime.Now,
                model.UserID,
                model.File.ContentType
            );

            if (result)
                return Ok(true);

            return BadRequest(false);
        }

        [Authorize(Roles = "SuperAdmin,Admin,Moderator")]
        [HttpGet("DownloadParticipantFile/{id}")]
        public async Task<IActionResult> DownloadParticipantFile(int id)
        {
            var attachment = await _service.DownloadParticipantFile(id);

            if (attachment == null || attachment.ActualFile == null)
                return NotFound();

            var contentType = string.IsNullOrWhiteSpace(attachment.ContentType)
                ? "application/octet-stream"
                : attachment.ContentType;

            return File(
                attachment.ActualFile,
                contentType,
                attachment.ActualFileName
            );
        }


        [Authorize(Roles = "SuperAdmin,Admin,Moderator")]
        [HttpGet("DownloadPersonalFile/{id}")]
        public async Task<IActionResult> DownloadPersonalFile(int id)
        {
            var attachment = await _service.DownloadPersonalFile(id);

            if (attachment == null || attachment.ActualFile == null)
                return NotFound();

             var contentType = string.IsNullOrWhiteSpace(attachment.ContentType)
              ? "application/octet-stream"
              : attachment.ContentType;

            return File(
                attachment.ActualFile,
                contentType,
                attachment.ActualFileName
            );
        }


        [Authorize(Roles = "SuperAdmin,Admin,Moderator")]
        [HttpGet("DownloadEmployeeFile/{id}")]
        public async Task<IActionResult> DownloadEmployeeFile(int id)
        {
            var attachment = await _service.DownloadEmployeeFile(id);

            if (attachment == null || attachment.ActualFile == null)
                return NotFound();

            var contentType = string.IsNullOrWhiteSpace(attachment.ContentType)
                ? "application/octet-stream"
                : attachment.ContentType;

            return File(
                attachment.ActualFile,
                contentType,
                attachment.ActualFileName
            );
        }

    }
}
