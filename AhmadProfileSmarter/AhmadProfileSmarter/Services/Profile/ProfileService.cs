using AhmadDAL.DataAccessLayer.Employees;
using AhmadDAL.DataAccessLayer.Profile;
using AhmadDAL.Models.Notifications;
using AhmadProfileSmarter.Interfaces;
using AhmadProfileSmarter.UnitofWork;

namespace AhmadService.Services.Profile
{
    public class ProfileService
    {
        // private readonly IProfile repository;

        private readonly IUnitOfWork _unitOfWork;

        public ProfileService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Notifications>> GetAllNotificationofReciever(int receiverId)
        {
            await _unitOfWork.BeginTransactionAsync(); // Start transaction

            try
            {
                // Call repository via UnitOfWork
                var notifications = await _unitOfWork.Profile.GetAllNotificationofReciever(receiverId);

                // Commit transaction
                await _unitOfWork.CommitTransactionAsync();

                return notifications;
            }
            catch
            {
                // Rollback if error occurs
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }
        
        
        public async Task<bool> MarkNotificationRead(int id)
        {
            await _unitOfWork.BeginTransactionAsync(); // Start transaction

            try
            {
                // Call repository via UnitOfWork
                var result = await _unitOfWork.Profile.MarkNotificationRead(id);

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

        public async Task<bool> ChangePassword(int userid , string pass)
        {
            await _unitOfWork.BeginTransactionAsync(); // Start transaction

            try
            {
                // Call repository via UnitOfWork
                var result = await _unitOfWork.Profile.ChangePassword(userid, pass);

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
