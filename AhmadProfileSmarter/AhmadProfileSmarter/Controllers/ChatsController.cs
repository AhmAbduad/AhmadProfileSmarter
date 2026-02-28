using AhmadService.dto.Chats;
using AhmadService.Services.Chats;
using AhmadService.Services.Drive;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AhmadAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ChatsController : ControllerBase
    {
        public readonly ChatsService _service;

        public ChatsController(ChatsService service)
        {
            _service = service;
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _service.GetAllUsers();
            if(users==null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        [HttpPost("SendChat")]
        public async Task<IActionResult> SendChat([FromBody] ChatsDto chat)
        {
            var response = await _service.SendChat(chat.ChatText,chat.SenderID,chat.ReceiverID,chat.MessageDate);

            if (response == null)
            {
                return BadRequest("Failed to save chat");
            }

            return Ok(response);
        }

        [HttpGet("GetMessages")]
        public async Task<IActionResult> GetMessages(int senderId, int receiverId)
        {
            var messages = await _service.GetMessages(senderId, receiverId);
            return Ok(messages);
        }

        [HttpPost("AIresponse")]
        public async Task<IActionResult> AIresponse([FromBody] string chat)
        {
            var result = await _service.AIresponse(chat);

            if(result==null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
