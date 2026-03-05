using AhmadDAL.DataAccessLayer.MeetingsVideo;
using AhmadDAL.DataAccessLayer.Profile;
using AhmadDAL.Models.Credentials;
using AhmadDAL.Models.Meetings;
using AhmadProfileSmarter.Interfaces;
using AhmadProfileSmarter.UnitofWork;
using AhmadService.dto.MeetingsVideo;

namespace AhmadService.Services.MeetingsVideo
{
    public class MeetingsVideoService
    {
        //private readonly IMeetingsVideo repository;
        private readonly IUnitOfWork _unitOfWork;

        public MeetingsVideoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Meetings> AddMeeting(MeetingsVideoDto meeting)
        {
            // 🔹 Begin transaction
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                // 🔹 Call repository via UnitOfWork
                var addedMeeting = await _unitOfWork.MeetingsVideo.AddMeeting(
                    meeting.Title,
                    meeting.Description,
                    meeting.StartTime,
                    meeting.EndTime,
                    meeting.CreatedBy,
                    meeting.MeetingLink,
                    meeting.TaskID,
                    meeting.Users
                );

                // 🔹 Save changes
                await _unitOfWork.SaveChangesAsync();

                // 🔹 Commit transaction
                await _unitOfWork.CommitTransactionAsync();

                return addedMeeting;
            }
            catch
            {
                // 🔹 Rollback on error
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }

        public async  Task<List<Meetings>> getAllMeetingsByUserId(int userid)
        {
            // 🔹 Begin transaction
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                // 🔹 Call repository via UnitOfWork
                var meetings = await _unitOfWork.MeetingsVideo.getAllMeetingsByUserId(userid);

                // 🔹 Commit transaction
                await _unitOfWork.CommitTransactionAsync();

                return meetings;
            }
            catch
            {
                // 🔹 Rollback if anything goes wrong
                await _unitOfWork.RollbackTransactionAsync();
                throw; // Bubble up exception
            }
        }

        public async Task<Meetings> EndMeeting(int id)
        {
            // 🔹 Begin transaction
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                // 🔹 Call repository via UnitOfWork
                var meeting = await _unitOfWork.MeetingsVideo.EndMeeting(id);

                // 🔹 Save changes (handled via UnitOfWork)
                await _unitOfWork.SaveChangesAsync();

                // 🔹 Commit transaction
                await _unitOfWork.CommitTransactionAsync();

                return meeting;
            }
            catch
            {
                // 🔹 Rollback if anything goes wrong
                await _unitOfWork.RollbackTransactionAsync();
                throw; // Bubble up the exception
            }
        }
    }
}
