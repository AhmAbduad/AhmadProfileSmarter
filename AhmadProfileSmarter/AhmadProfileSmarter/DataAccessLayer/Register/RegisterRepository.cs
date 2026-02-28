using AhmadDAL.Data;
using AhmadDAL.Models.Credentials;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AhmadDAL.DataAccessLayer.Register
{
    public class RegisterRepository
    {
        private readonly AppDbContext _context;

        public RegisterRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetUsernameandEmail()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<bool> RegisterUser(string UserName, string Email, string Password)
        {
            // 🔹 Check if user already exists
            if (await _context.Users.AnyAsync(u => u.Email == Email))
                return false;

            var hasher = new PasswordHasher<User>();

            var newUser = new User
            {
                UserName = UserName,
                Email = Email
            };

            // 🔐 Hash password
            newUser.PasswordHash = hasher.HashPassword(newUser, Password);

            // 🔹 Save to database
            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
