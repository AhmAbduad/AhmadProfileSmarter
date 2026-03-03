using AhmadDAL.Models.Meetings;

namespace AhmadProfileSmarter.Interfaces
{
    public interface IMeetingsVideo
    {
        Task<Meetings> AddMeeting(string? Title, string? Description, DateTime StartTime, DateTime EndTime, int CreatedBy, string? MeetingLink, int TaskID, List<int> users);

        Task<List<Meetings>> getAllMeetingsByUserId(int userid);

        Task<Meetings?> EndMeeting(int id);
    }
}
