using AhmadDAL.DataAccessLayer.Dashboard;
using AhmadDAL.DataAccessLayer.Register;
using AhmadDAL.Models.Activity;
using AhmadDAL.Models.Meetings;
using AhmadProfileSmarter.Interfaces;

namespace AhmadService.Services.Dashboard
{
    public class DashboardService
    {
        private readonly IDashboard repository;

        public DashboardService(IDashboard repository)
        {
            this.repository = repository;
        }

        public async Task<List<Meetings>> GetAllMeetings()
        {
            return await repository.GetAllMeetings();
        }


        public async Task<int> GetTotalParticipants()
        {
            return await repository.GetTotalParticipants();
        }

        public async Task<int> GetActiveParticipants()
        {
            return await repository.GetActiveParticipants();
        }


        public async Task<int> GetInActiveParticipants()
        {
            return await repository.GetInActiveParticipants();
        }


        public async Task<int> GetCompletedTasksCount()
        {
            return await repository.GetCompletedTasksCount();
        }

        public async Task<List<Activity>> GetActivityforDashboard()
        {
            return await repository.GetActivityforDashboard();
        }


        
    }
}
