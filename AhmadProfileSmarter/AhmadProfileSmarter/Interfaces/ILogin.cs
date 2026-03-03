using AhmadDAL.Models.Credentials;

namespace AhmadProfileSmarter.Interfaces
{
    public interface ILogin
    {
        Task<User?> ValidateUserCredentials(string email, string password);


    }
}
