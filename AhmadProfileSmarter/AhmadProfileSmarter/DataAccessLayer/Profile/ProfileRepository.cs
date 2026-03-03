using AhmadDAL.Data;
using AhmadDAL.Models.Credentials;
using AhmadDAL.Models.Notifications;
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

                await _context.SaveChangesAsync();

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

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
