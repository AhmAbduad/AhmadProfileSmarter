using AhmadDAL.DataAccessLayer.Employees;
using AhmadDAL.DataAccessLayer.Profile;
using AhmadDAL.Models.Notifications;

namespace AhmadService.Services.Profile
{
    public class ProfileService
    {
        private readonly ProfileRepository repository;

        public ProfileService(ProfileRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<Notifications>> GetAllNotificationofReciever(int receiverId)
        {
            return await repository.GetAllNotificationofReciever(receiverId);
        }
        
        
        public async Task<bool> MarkNotificationRead(int id)
        {
            return await repository.MarkNotificationRead(id);
        }

        public async Task<bool> ChangePassword(int userid , string pass)
        {
            return await repository.ChangePassword(userid,pass);
        }
    }
}
