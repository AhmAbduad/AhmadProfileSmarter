using AhmadDAL.DataAccessLayer.MeetingsVideo;
using AhmadDAL.DataAccessLayer.Profile;
using AhmadDAL.Models.Credentials;
using AhmadDAL.Models.Meetings;
using AhmadService.dto.MeetingsVideo;

namespace AhmadService.Services.MeetingsVideo
{
    public class MeetingsVideoService
    {
        private readonly MeetingsVideoRepository repository;

        public MeetingsVideoService(MeetingsVideoRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Meetings> AddMeeting(MeetingsVideoDto meeting)
        {
            return await repository.AddMeeting(meeting.Title,meeting.Description,meeting.StartTime,meeting.EndTime,meeting.CreatedBy,meeting.MeetingLink,meeting.TaskID,meeting.Users);
        }

        public async  Task<List<Meetings>> getAllMeetingsByUserId(int userid)
        {
            return await repository.getAllMeetingsByUserId(userid);
        }

        public async Task<Meetings> EndMeeting(int id)
        {
            return await repository.EndMeeting(id);
        }
    }
}
