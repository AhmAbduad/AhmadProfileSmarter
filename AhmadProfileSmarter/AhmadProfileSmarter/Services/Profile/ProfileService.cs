using AhmadDAL.DataAccessLayer.Employees;
using AhmadDAL.DataAccessLayer.Profile;
using AhmadDAL.Models.Notifications;
using AhmadProfileSmarter.Interfaces;

namespace AhmadService.Services.Profile
{
    public class ProfileService
    {
        private readonly IProfile repository;

        public ProfileService(IProfile repository)
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
