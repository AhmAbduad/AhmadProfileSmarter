using AhmadDAL.Data;
using AhmadDAL.Models.Activity;
using AhmadDAL.Models.Meetings;
using AhmadProfileSmarter.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AhmadDAL.DataAccessLayer.Dashboard
{
    public class DashboardRepository:IDashboard
    {
        private readonly AppDbContext _context;

        public DashboardRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Meetings>> GetAllMeetings()
        {
            return await _context.Meetings.ToListAsync();
        }

        public async Task<int> GetTotalParticipants()
        {
            return await _context.Participants.CountAsync();
        }

        public async Task<int> GetActiveParticipants()
        {
            return await _context.Participants
          .Where(p => p.IsActive)
          .CountAsync();
        }

        public async Task<int> GetInActiveParticipants()
        {
            return await _context.Participants
          .Where(p => !p.IsActive)
          .CountAsync();
        }

        public async Task<int> GetCompletedTasksCount()
        {
                return await _context.Tasks
            .Where(t => t.Status.StatusName == "Completed")
            .CountAsync();
        }

        public async Task<List<Activity>> GetActivityforDashboard()
        {
            return await _context.Activities.ToListAsync();
        }
    }
}
