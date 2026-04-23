using AhmadDAL.Data;
using AhmadDAL.Models.Credentials;
using AhmadProfileSmarter.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AhmadDAL.DataAccessLayer.Register
{
    public class RegisterRepository:IRegister
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



            var newUser = new User
            {
                UserName = UserName,
                Email = Email,
                PasswordHash = Password,  // ❌ Storing plain text password!
                RoleID = 4
            };

            await _context.Users.AddAsync(newUser);

            return true;
            //var hasher = new PasswordHasher<User>();

            //var newUser = new User
            //{
            //    UserName = UserName,
            //    Email = Email,
            //    RoleID=4
            //};

            // 🔐 Hash password
            // newUser.PasswordHash = hasher.HashPassword(newUser, Password);

            // 🔹 Save to database
            //await _context.Users.AddAsync(newUser);
            ////await _context.SaveChangesAsync();

            //return true;
        }
    }
}
