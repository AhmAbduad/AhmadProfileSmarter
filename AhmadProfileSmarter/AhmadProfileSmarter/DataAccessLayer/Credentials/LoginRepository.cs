using AhmadDAL.Data;
using AhmadDAL.Models.Credentials;
using AhmadProfileSmarter.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AhmadDAL.DataAccessLayer.Credentials
{
    public class LoginRepository : ILogin
    {

        private readonly AppDbContext _context;

        public LoginRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User?> ValidateUserCredentials(string email, string password)
        {
            //var user = await _context.Users
            //.FirstOrDefaultAsync(u => u.Email == email);

            var user = await _context.Users
            .Include(u => u.Role)   // 👈 Role table join ho jae ga
            .FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
                return null;

            var hasher = new PasswordHasher<User>();

            var result = hasher.VerifyHashedPassword(
                user,
                user.PasswordHash,
                password
            );

            if (result == PasswordVerificationResult.Failed)
                return null;

            return user;
        }

    }
}
