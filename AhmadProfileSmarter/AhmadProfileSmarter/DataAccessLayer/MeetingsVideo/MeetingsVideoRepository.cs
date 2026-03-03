using AhmadDAL.Data;
using AhmadDAL.Models.Credentials;
using AhmadDAL.Models.Meetings;
using AhmadProfileSmarter.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace AhmadDAL.DataAccessLayer.MeetingsVideo
{
    public class MeetingsVideoRepository:IMeetingsVideo
    {
        private readonly AppDbContext _context;

        public MeetingsVideoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Meetings> AddMeeting(string? Title,string? Description, DateTime StartTime, DateTime EndTime, int CreatedBy, string? MeetingLink, int TaskID, List<int> users)
        {
            // Generate unique meeting link
            string roomName = $"Meeting_{Guid.NewGuid().ToString("N")}";
            string newmeetingLink = $"https://meet.jit.si/{roomName}";

            var newMeeting = new Meetings
            {
                Title = Title,
                Description = Description,
                StartTime = StartTime,
                EndTime = EndTime,
                CreatedBy = CreatedBy,
                TaskID = TaskID,
                MeetingLink = newmeetingLink,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _context.Meetings.Add(newMeeting);
            await _context.SaveChangesAsync();

            // Add participants
            foreach (var userId in users)
            {
                var participant = new MeetingParticipants
                {
                    MeetingID = newMeeting.MeetingID,
                    UserID = userId,
                    IsHost = (userId == CreatedBy),
                    JoinedAt = null
                };
                _context.MeetingParticipants.Add(participant);
            }

            await _context.SaveChangesAsync();

            return newMeeting;
        }
           
        public async Task<List<Meetings>> getAllMeetingsByUserId(int userid)
        {


            // Fetch meetings where the user is either the creator or a participant
            var meetings = await _context.Meetings
                .Include(m => m.MeetingPart)            // Include participants
                .ThenInclude(mp => mp.User)             // Include user info for each participant
                .Where(m => !m.IsDeleted &&
                            (m.CreatedBy == userid ||
                             m.MeetingPart.Any(mp => mp.UserID == userid)))  // Filter by creator or participant
                .OrderByDescending(m => m.StartTime)   // Latest meetings first
                .ToListAsync();

            return meetings;

        }

        public async Task<Meetings?> EndMeeting(int id)
        {
            var meeting = await _context.Meetings.FindAsync(id);

            if (meeting == null)
                return null;   // important check

            meeting.IsDeleted = true;
            meeting.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return meeting;
        }
    }
}
