using AhmadDAL.DataAccessLayer.Register;
using AhmadDAL.Models.Credentials;
using AhmadProfileSmarter.Interfaces;
using AhmadService.dto.Register;

namespace AhmadService.Services.Register
{
    public class RegisterService
    {
        private readonly IRegister repository;

        public RegisterService(IRegister repository)
        {
            this.repository = repository;
            
        
        }

        public async Task<List<User>> GetUsernameandEmail()
        {
            return await repository.GetUsernameandEmail();
        }

        public async Task<bool> RegisterUser(RegisterDto model)
        {
            return await repository.RegisterUser(model.UserName, model.Email,model.Password);
        }

    }
}
