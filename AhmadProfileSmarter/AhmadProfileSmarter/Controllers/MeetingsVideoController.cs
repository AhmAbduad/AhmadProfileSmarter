using AhmadDAL.Models.Meetings;
using AhmadService.dto.MeetingsVideo;
using AhmadService.Services.MeetingsVideo;
using AhmadService.Services.Profile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AhmadAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MeetingsVideoController : Controller
    {
        public readonly MeetingsVideoService _service;

        public MeetingsVideoController(MeetingsVideoService service)
        {
            _service = service;
        }

        [HttpPost("AddMeeting")]
        public async Task<IActionResult> AddMeeting([FromBody] MeetingsVideoDto meeting)
        {
            if (meeting == null)
            {
                return BadRequest("Invalid meeting data");

            }


            try
            {
                var result = await _service.AddMeeting(meeting);

                var response = new MeetingsVideoDto
                {
                    //MeetingID = result.MeetingID,
                    Title = result.Title,
                    Description = result.Description,
                    StartTime = result.StartTime,
                    EndTime = result.EndTime,
                    CreatedBy = result.CreatedBy,
                    TaskID = result.TaskID,
                    MeetingLink = result.MeetingLink,
                    //ParticipantUserIds = result.Users
                };

                return Ok(response);
                //return Ok(result); // Must return JSON
            }
            catch (Exception ex)
            {
                // Log error
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("getAllMeetingsByUserId")]
        public async Task<IActionResult> getAllMeetingsByUserId(int userid)
        {
            //var result = await _service.getAllMeetingsByUserId(userid);

            //if (result == null)
            //{
            //    return NotFound();
            //}

            //return Ok(result);

            // Get raw Meetings entities from service
            var meetings = await _service.getAllMeetingsByUserId(userid);

            if (meetings == null || !meetings.Any())
                return NotFound(new { message = "No meetings found for this user." });

            // Map EF entities to DTOs here
            var result = meetings.Select(m => new MeetingDto
            {
                MeetingID = m.MeetingID,
                Title = m.Title ?? string.Empty,
                Description = m.Description ?? string.Empty,
                StartTime = m.StartTime,
                EndTime = m.EndTime,
                MeetingLink = m.MeetingLink ?? string.Empty,
                Participants = m.MeetingPart.Select(mp => new MeetingParticipantDto
                {
                    UserID = mp.UserID,
                    IsHost = mp.IsHost,
                    UserName = mp.User?.UserName ?? string.Empty
                }).ToList()
            }).ToList();

            return Ok(result);
        }


        [HttpPut("EndMeeting/{id}")]
        public async Task<IActionResult> EndMeeting(int id)
        {
            var result = await _service.EndMeeting(id);
            if (result == null)
                return NotFound(new { message = "Meeting not found" });

            return Ok(new { message = "Meeting ended successfully" });
        }

    }
}
