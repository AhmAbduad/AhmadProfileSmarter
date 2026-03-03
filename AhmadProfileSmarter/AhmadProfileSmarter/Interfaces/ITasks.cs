using AhmadDAL.Models.Activity;
using AhmadDAL.Models.Attachment;
using AhmadDAL.Models.Comments;
using AhmadDAL.Models.Meetings;

namespace AhmadProfileSmarter.Interfaces
{
    public interface ITasks
    {
        Task<object> GetAllTasks();

        Task<List<AhmadDAL.Models.Status.Status>> GetAllStatus();

        Task<List<AhmadDAL.Models.Account.Account>> GetAllAccounts();

        Task<bool> SubmitTask(string TaskName, string LateDays, string Salary, DateTime LastActivity, int StatusID, int AccountID);

        Task<object?> GetTaskById(int id);

        Task<bool> SubmitAttachment(int id, IFormFile formFile);

        Task<List<Attachment>> GetAttachmentsByTaskId(int taskId);

        Task<Attachment?> GetAttachmentById(int attachmentId);

        Task<List<Comments>> GettingComments(int id);

        Task<bool> SubmitComment(int taskid, string comment);

        Task<List<Activity>> GettingActivity(int id);

        Task<bool> ApproveStatus(int id);

        Task<List<Meetings>> GetAllMeetingsByTaskID(int id);
    }
}
