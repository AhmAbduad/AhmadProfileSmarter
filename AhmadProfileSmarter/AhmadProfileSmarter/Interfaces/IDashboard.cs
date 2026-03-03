using AhmadDAL.Models.Activity;
using AhmadDAL.Models.Meetings;

namespace AhmadProfileSmarter.Interfaces
{
    public interface IDashboard
    {
        Task<List<Meetings>> GetAllMeetings();

        Task<int> GetTotalParticipants();

        Task<int> GetActiveParticipants();

        Task<int> GetInActiveParticipants();

        Task<int> GetCompletedTasksCount();

        Task<List<Activity>> GetActivityforDashboard();

    }
}
