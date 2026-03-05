using AhmadDAL.DataAccessLayer.Register;
using AhmadDAL.Models.Credentials;
using AhmadProfileSmarter.Interfaces;
using AhmadProfileSmarter.UnitofWork;
using AhmadService.dto.Register;

namespace AhmadService.Services.Register
{
    public class RegisterService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegisterService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<User>> GetUsernameandEmail()
        {
            await _unitOfWork.BeginTransactionAsync(); // Start transaction

            try
            {
                // Call repository via UnitOfWork
                var users = await _unitOfWork.Register.GetUsernameandEmail();

                // Commit transaction
                await _unitOfWork.CommitTransactionAsync();

                return users;
            }
            catch
            {
                // Rollback if error occurs
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }

        public async Task<bool> RegisterUser(RegisterDto model)
        {
            await _unitOfWork.BeginTransactionAsync(); // Start transaction

            try
            {
                // Call repository through UnitOfWork
                var result = await _unitOfWork.Register.RegisterUser(
                    model.UserName,
                    model.Email,
                    model.Password
                );

                // Save changes
                await _unitOfWork.SaveChangesAsync();

                // Commit transaction
                await _unitOfWork.CommitTransactionAsync();

                return result;
            }
            catch
            {
                // Rollback if error occurs
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }
    }
}
