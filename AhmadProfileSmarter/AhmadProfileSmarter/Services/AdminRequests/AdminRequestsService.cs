using AhmadDAL.DataAccessLayer.AdminRequests;
using AhmadDAL.DataAccessLayer.Dashboard;
using AhmadProfileSmarter.Interfaces;
using AhmadProfileSmarter.UnitofWork;
using AhmadService.dto.AdminRequests;

namespace AhmadService.Services.AdminRequests
{
    public class AdminRequestsService
    {
        // private readonly IAdminRequests repository;

        private readonly IUnitOfWork _unitOfWork;

        public AdminRequestsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AhmadDAL.Models.AdminRequests.AdminRequests> CreateRequest(CreateRequestDto dto)
        {
            // 🔹 Start a transaction
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                // 🔹 Call the repository method via UnitOfWork
                var request = await _unitOfWork.AdminRequests.CreateRequest(
                    dto.UserId,
                    dto.RequestType,
                    dto.Title,
                    dto.Description,
                    dto.Status,
                    dto.AdminRemarks
                );

                // 🔹 Save changes
                await _unitOfWork.SaveChangesAsync();

                // 🔹 Commit transaction
                await _unitOfWork.CommitTransactionAsync();

                return request;
            }
            catch
            {
                // 🔹 Rollback if anything goes wrong
                await _unitOfWork.RollbackTransactionAsync();
                throw; // Bubble up the exception
            }
        }

        public async Task<List<AhmadDAL.Models.AdminRequests.AdminRequests>> GetAdminRequestonID(int id)
        {
            // 🔹 Start a transaction (optional for read, but consistent)
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                // 🔹 Call repository via UnitOfWork
                var requests = await _unitOfWork.AdminRequests.GetAdminRequestonID(id);

              

                // 🔹 Commit transaction
                await _unitOfWork.CommitTransactionAsync();

                return requests;
            }
            catch
            {
                // 🔹 Rollback if something goes wrong
                await _unitOfWork.RollbackTransactionAsync();
                throw; // bubble up exception
            }
        }
    }
}
