using AhmadDAL.Data;
using AhmadDAL.DataAccessLayer.Tasks;
using AhmadDAL.Models.Comments;
using AhmadService.dto.Attachment;
using AhmadService.dto.Comment;
using AhmadService.dto.Tasks;
using AhmadService.Services.Credentials;
using AhmadService.Services.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AhmadAPI.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {

        public readonly TasksService _service;
        public TasksController(TasksService service)
        {
            _service = service;
        }

        [Authorize(Roles = "SuperAdmin,Admin,Moderator")]
        [HttpGet("GetAllTasks")]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await _service.GetAllTasks();

            if (tasks == null)
                return NotFound("No tasks found");

            return Ok(tasks);
        }


        [Authorize(Roles = "SuperAdmin,Admin,Moderator")]
        [HttpGet("GetAllStatus")]
        public async Task<IActionResult> GetAllStatus()
        {
            var status = await _service.GetAllStatus();

            if (status == null || status.Count == 0)
            {
                return NotFound("No Status Found");
            }

            return Ok(status);
        }

        [Authorize(Roles = "SuperAdmin,Admin,Moderator")]
        [HttpGet("GetAllAccounts")]
        public async Task<IActionResult> GetAllAccounts()
        {
            var accounts = await _service.GetAllAccounts();

            if (accounts == null || accounts.Count == 0)
            {
                return NotFound("No Accounts Found");
            }

            return Ok(accounts);
        }

        [Authorize(Roles = "SuperAdmin,Admin,Moderator")]
        [HttpPost("SubmitTask")]
        public async Task<bool> SubmitTask([FromBody] TasksDto taskdto)
        {
            if (taskdto.TaskName == null || taskdto.LateDays == null || taskdto.Salary == null)
            {
                return false;
            }

            bool check = await _service.SubmitTask(taskdto);

            return check;
        }

        [Authorize(Roles = "SuperAdmin,Admin,Moderator")]
        [HttpGet("GetTaskById/{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var task = await _service.GetTaskById(id);

            return Ok(task);
        }

        [Authorize(Roles = "SuperAdmin,Admin,Moderator")]
        [HttpPost("SubmitAttachment")]
        public async Task<bool> SubmitAttachment([FromForm] AttachmentDto model)
        {
            if (model.File == null || model.File.Length == 0)
                return false;


            return await _service.SubmitAttachment(model.TaskID, model.File);
        }

        [Authorize(Roles = "SuperAdmin,Admin,Moderator")]
        [HttpGet("GetAttachmentsByTaskId/{taskId}")]
        public async Task<IActionResult> GetAttachmentsByTaskId(int taskId)
        {
            var attachments = await _service.GetAttachmentsByTaskId(taskId);

            if (!attachments.Any())
                return NotFound();

            return Ok(attachments.Select(a => new
            {
                a.AttachmentID,
                a.AttachmentFile,
                a.Size,
                a.UploadDate,
                a.FileName,
                a.ContentType
            }));

        }

        [Authorize(Roles = "SuperAdmin,Admin,Moderator")]
        [HttpGet("GetAttachmentFile/{id}")]
        public async Task<IActionResult> GetAttachmentFile(int id)
        {
            var attachment = await _service.GetAttachmentById(id);

            if (attachment == null || attachment.AttachmentFile == null)
                return NotFound();

            return File(
                attachment.AttachmentFile,
                attachment.ContentType ?? "application/octet-stream",
                attachment.FileName
            );
        }

        [Authorize(Roles = "SuperAdmin,Admin,Moderator")]
        [HttpGet("GettingComments/{id}")]
        public async Task<IActionResult> GettingComments(int id)
        {
            var comments = await _service.GettingComments(id);

            return Ok(comments);
        }

        [Authorize(Roles = "SuperAdmin,Admin,Moderator")]
        [HttpPost("SubmitComment")]
        public async Task<IActionResult> SubmitComment([FromBody] SubmitCommentDto comment)
        {
            var response = await _service.SubmitComment(comment.TaskID, comment.Comment);

            if(response==true)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [Authorize(Roles = "SuperAdmin,Admin,Moderator")]
        [HttpGet("GettingActivity/{id}")]
        public async Task<IActionResult> GettingActivity(int id)
        {
            var activity = await _service.GettingActivity(id);
            return Ok(activity);
        }

        [Authorize(Roles = "SuperAdmin,Admin,Moderator")]
        [HttpPost("ApproveStatus/{id}")]
        public async Task<IActionResult> ApproveStatus(int id)
        {
            var response = await _service.ApproveStatus(id);

            if (!response)
                return BadRequest("Failed to approve task");

            return Ok(true);
        }

        [Authorize(Roles = "SuperAdmin,Admin,Moderator")]
        [HttpGet("GetAllMeetingsByTaskID/{id}")]
        public async Task<IActionResult> GetAllMeetingsByTaskID(int id)
        {
            var meetings = await _service.GetAllMeetingsByTaskID(id);

            return Ok(meetings);
        }
    }
}
