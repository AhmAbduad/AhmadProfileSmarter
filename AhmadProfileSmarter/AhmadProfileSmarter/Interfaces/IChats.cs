using AhmadDAL.Models.AIChatMessage;
using AhmadDAL.Models.Credentials;

namespace AhmadProfileSmarter.Interfaces
{
    public interface IChats
    {
        Task<List<User>> GetAllUsers();

        Task<AhmadDAL.Models.Chats.Chats> SendChat(string ChatText, int SenderID, int ReceiverID, DateTime MessageDate);

        Task<List<AhmadDAL.Models.Chats.Chats>> GetMessages(int senderId, int receiverId);

        Task<AIChatMessage> AIresponse(string userText);
    }
}
