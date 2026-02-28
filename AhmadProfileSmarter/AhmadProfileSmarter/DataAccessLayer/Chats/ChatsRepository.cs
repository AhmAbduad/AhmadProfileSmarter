using AhmadDAL.Data;
using AhmadDAL.Models.AIChatMessage;
using AhmadDAL.Models.Chats;
using AhmadDAL.Models.Credentials;
using AhmadDAL.Models.HuggingFaceResponse;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Text;
using System.Text.Json;

namespace AhmadDAL.DataAccessLayer.Chats
{
    public class ChatsRepository
    {

        private readonly HttpClient _http = new HttpClient();
        private const string apiToken = "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"; // free to get

        private readonly AppDbContext _context;
        
        public ChatsRepository(AppDbContext context)
        {
            _context = context;

           
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<AhmadDAL.Models.Chats.Chats> SendChat(string ChatText, int SenderID, int ReceiverID, DateTime MessageDate)
        {
            if (string.IsNullOrWhiteSpace(ChatText))
                throw new ArgumentException("Chat text cannot be empty.");

            if (SenderID <= 0 || ReceiverID <= 0)
                throw new ArgumentException("Invalid Sender, Receiver.");

            var messagetime = DateTime.Now;
            // 2️⃣ Create Chat Object
            var chat = new AhmadDAL.Models.Chats.Chats
            {
                ChatText = ChatText,
                SenderID = SenderID,
                ReceiverID = ReceiverID,
                MessageDate = messagetime
            };

            // 3️⃣ Add to Database
            await _context.Chats.AddAsync(chat);

            // 4️⃣ Save Changes
            await _context.SaveChangesAsync();

            // 5️⃣ Return Created Chat
            return chat;
        }

        
        public async Task<List<AhmadDAL.Models.Chats.Chats>> GetMessages(int senderId, int receiverId)
        {

            var messages = await _context.Chats
                 .Include(x => x.Sender)
                 .Include(x => x.Receiver)
                 .Where(x =>
                     (x.SenderID == senderId && x.ReceiverID == receiverId) ||
                     (x.SenderID == receiverId && x.ReceiverID == senderId)
                 )
                 .OrderBy(x => x.MessageDate)
                 .ToListAsync();

            return messages;
        }


        public async Task<AIChatMessage> AIresponse(string userText)
        {
            var requestBody = new
            {
                messages = new[]
                {
                    new { role = "user", content = userText }
            }
                };

            var request = new HttpRequestMessage(
                HttpMethod.Post,
                "https://router.huggingface.co/hf-inference/models/gpt2"
            );

            request.Content = new StringContent(
                JsonSerializer.Serialize(requestBody),
                Encoding.UTF8,
                "application/json");

            request.Headers.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiToken);

            var response = await _http.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new Exception("HuggingFace Error: " + content);

            using var doc = JsonDocument.Parse(content);
            var aiText = doc.RootElement
                            .GetProperty("choices")[0]
                            .GetProperty("message")
                            .GetProperty("content")
                            .GetString();

            var chatMessage = new AIChatMessage
            {
                MessageText = aiText
            };

            _context.AIChatMessages.Add(chatMessage);
            await _context.SaveChangesAsync();

            return chatMessage;
        }
    }
}
