using AhmadDAL.DataAccessLayer.Dashboard;
using AhmadDAL.DataAccessLayer.Register;
using AhmadDAL.Models.Activity;
using AhmadDAL.Models.Meetings;
using AhmadProfileSmarter.Interfaces;
using AhmadProfileSmarter.UnitofWork;

namespace AhmadService.Services.Dashboard
{
    public class DashboardService
    {
       // private readonly IDashboard repository;

        private readonly IUnitOfWork _unitOfWork;

        public DashboardService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Meetings>> GetAllMeetings()
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                var meetings = await _unitOfWork.Dashboard.GetAllMeetings();

                await _unitOfWork.CommitTransactionAsync();
                return meetings;
            }
            catch
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }


        public async Task<int> GetTotalParticipants()
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                var total = await _unitOfWork.Dashboard.GetTotalParticipants();

                await _unitOfWork.CommitTransactionAsync();

                return total;
            }
            catch
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }

        public async Task<int> GetActiveParticipants()
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                var activeCount = await _unitOfWork.Dashboard.GetActiveParticipants();
                // agar yeh Dashboard repository mein hai to:
                // var activeCount = await _unitOfWork.Dashboard.GetActiveParticipants();

                await _unitOfWork.CommitTransactionAsync();

                return activeCount;
            }
            catch
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }


        public async Task<int> GetInActiveParticipants()
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                var inActiveCount = await _unitOfWork.Dashboard.GetInActiveParticipants();
                // agar Dashboard repository mein hai to:
                // var inActiveCount = await _unitOfWork.Dashboard.GetInActiveParticipants();

                await _unitOfWork.CommitTransactionAsync();

                return inActiveCount;
            }
            catch
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }


        public async Task<int> GetCompletedTasksCount()
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                var completedCount = await _unitOfWork.Dashboard.GetCompletedTasksCount();
                // agar yeh Dashboard repository mein hai to:
                // var completedCount = await _unitOfWork.Dashboard.GetCompletedTasksCount();

                await _unitOfWork.CommitTransactionAsync();

                return completedCount;
            }
            catch
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }

        public async Task<List<Activity>> GetActivityforDashboard()
        {
            await _unitOfWork.BeginTransactionAsync(); // 🔹 Start transaction

            try
            {
                // 🔹 Call repository via UnitOfWork
                var activities = await _unitOfWork.Dashboard.GetActivityforDashboard();

                // 🔹 Commit transaction (optional for read, but for consistency)
                await _unitOfWork.CommitTransactionAsync();

                return activities;
            }
            catch
            {
                // 🔹 Rollback if anything goes wrong
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }


        
    }
}
