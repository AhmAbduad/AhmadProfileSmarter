using AhmadDAL.Data;
using AhmadDAL.Models.Credentials;
using AhmadDAL.Models.Notifications;
using AhmadProfileSmarter.dto.Notification;
using AhmadProfileSmarter.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AhmadDAL.DataAccessLayer.Profile
{
    public class ProfileRepository:IProfile
    {
        private readonly AppDbContext _context;

        public ProfileRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Notifications>> GetAllNotificationofReciever(int receiverId)
        {
            return await _context.Notifications
            .Where(n => n.ReceiverId == receiverId && !n.IsDeleted)
            .OrderByDescending(n => n.CreatedAt)
            .ToListAsync();
        }

        public async Task<bool> MarkNotificationRead(int id)
        {
            try
            {
                var notification = await _context.Notifications
                                                 .FirstOrDefaultAsync(n => n.Id == id);

                if (notification == null)
                    return false;

                notification.IsRead = true;

               

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }


        public async Task<bool> ChangePassword(int userid, string pass)
        {
            try
            {
                var user = await _context.Users
                                         .FirstOrDefaultAsync(u => u.UserId == userid);

                if (user == null)
                    return false;

                var hasher = new PasswordHasher<User>();

                // 🔐 Hash new password
                user.PasswordHash = hasher.HashPassword(user, pass);

             

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<AhmadProfileSmarter.Models.Roles.Roles>> FetchRoles()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<bool> CreateNotification(NotificationDto dto)
        {
            try
            {
                // 1️⃣ Create a new Notification entity
                var notification = new Notifications
                {
                    Title = dto.title,
                    Message = dto.message,
                    NotificationType = dto.notificationType,
                    SenderId = dto.senderId,
                    ReceiverId = dto.receiverId,
                    IsRead = false,
                    CreatedAt = DateTime.Now,
                    IsDeleted = false
                };

                // 2️⃣ Add to DbContext
                _context.Notifications.Add(notification);

                // 3️⃣ Save changes to database
                //await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                // Log exception if needed
                Console.WriteLine($"Error creating notification: {ex.Message}");
                return false;
            }
        }
    }
}
