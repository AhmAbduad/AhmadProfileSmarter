using AhmadDAL.DataAccessLayer.Chats;
using AhmadDAL.DataAccessLayer.Drive;
using AhmadDAL.Models.AIChatMessage;
using AhmadDAL.Models.Chats;
using AhmadDAL.Models.Credentials;
using AhmadService.dto.Chats;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AhmadService.Services.Chats
{
    public class ChatsService
    {
        private readonly ChatsRepository repository;

        public ChatsService(ChatsRepository repository)
        {

            this.repository = repository;
        }


        public async Task<List<User>> GetAllUsers()
        {
            return await repository.GetAllUsers();
        }

        public async Task<AhmadDAL.Models.Chats.Chats> SendChat(string ChatText,int SenderID,int ReceiverID, DateTime MessageDate)
        {
            return await repository.SendChat(ChatText,SenderID,ReceiverID,MessageDate);
        }
        public async Task<List<ChatsDto>> GetMessages(int senderId, int receiverId)
        {
            // Repository layer ko call karen
            var chats = await repository.GetMessages(senderId, receiverId);

            // Agar additional business logic chahiye to yahan apply karein
            // Example: map to DTO, sort, filter, etc.

            var chatDtos = chats
                .OrderBy(c => c.MessageDate)
                .Select(c => new ChatsDto
                {
                    ChatID = c.ChatID,
                    ChatText = c.ChatText,
                    SenderID = c.SenderID,
                    ReceiverID = c.ReceiverID,
                    MessageDate = c.MessageDate,

                   
                })
                .ToList();

            return chatDtos;
        }

        public async Task<AIChatMessage> AIresponse(string text)
        {
            return await repository.AIresponse(text);
        }

    }
}
