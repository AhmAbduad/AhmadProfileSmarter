using AhmadDAL.Models.Notifications;
using AhmadProfileSmarter.dto.Notification;

namespace AhmadProfileSmarter.Interfaces
{
    public interface IProfile
    {
        Task<List<Notifications>> GetAllNotificationofReciever(int receiverId);

        Task<bool> MarkNotificationRead(int id);

        Task<bool> ChangePassword(int userid, string pass);

        Task<List<AhmadProfileSmarter.Models.Roles.Roles>> FetchRoles();

        Task<bool> CreateNotification(NotificationDto dto);
    }
}
