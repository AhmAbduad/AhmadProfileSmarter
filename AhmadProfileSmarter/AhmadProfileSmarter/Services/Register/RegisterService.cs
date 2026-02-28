using AhmadDAL.DataAccessLayer.Register;
using AhmadDAL.Models.Credentials;
using AhmadService.dto.Register;

namespace AhmadService.Services.Register
{
    public class RegisterService
    {
        private readonly RegisterRepository repository;

        public RegisterService(RegisterRepository repository)
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
