using AhmadDAL.Data;
using AhmadDAL.Models.Credentials;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AhmadDAL.DataAccessLayer.Credentials
{
    public class LoginRepository
    {

        private readonly AppDbContext _context;

        public LoginRepository(AppDbContext context)
        {
            _context = context;
        }


        //public async Task<List<User>> ValidateUserCredentials(string email, string password)
        //{
        //    var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        //    if (user == null)
        //        return 

        //    // Compare password (for now, plain text)
        //    if (user.Password != password)
        //        return false;

        //    return true;
        //}

        public async Task<User?> ValidateUserCredentials(string email, string password)
        {
            var user = await _context.Users
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
