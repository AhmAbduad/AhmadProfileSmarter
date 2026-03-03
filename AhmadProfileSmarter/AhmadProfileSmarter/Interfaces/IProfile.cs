using AhmadDAL.Models.Notifications;

namespace AhmadProfileSmarter.Interfaces
{
    public interface IProfile
    {
        Task<List<Notifications>> GetAllNotificationofReciever(int receiverId);

        Task<bool> MarkNotificationRead(int id);

        Task<bool> ChangePassword(int userid, string pass);


    }
}
