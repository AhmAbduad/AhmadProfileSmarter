using AhmadDAL.Models.Credentials;

namespace AhmadProfileSmarter.Interfaces
{
    public interface IRegister
    {
        Task<List<User>> GetUsernameandEmail();

        Task<bool> RegisterUser(string UserName, string Email, string Password);
    }
}
