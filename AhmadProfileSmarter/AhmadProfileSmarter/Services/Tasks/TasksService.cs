using AhmadDAL.DataAccessLayer.Tasks;
using AhmadDAL.Models.Activity;
using AhmadDAL.Models.Attachment;
using AhmadDAL.Models.Comments;
using AhmadDAL.Models.Meetings;
using AhmadDAL.Models.Status;
using AhmadService.dto.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace AhmadService.Services.Tasks
{
    public class TasksService
    {
        private readonly TasksRepository repository;

        public TasksService(TasksRepository repository)
        {

            this.repository = repository;
        }


        public async Task<object> GetAllTasks()
        {
            return await repository.GetAllTasks();
        }

        public async Task<List<AhmadDAL.Models.Status.Status>> GetAllStatus()
        {
            return await repository.GetAllStatus();
        }

        public async Task<List<AhmadDAL.Models.Account.Account>> GetAllAccounts()
        {
            return await repository.GetAllAccounts();
        }

        public async Task<bool> SubmitTask(TasksDto taskdto)
        {
            if(taskdto.LastActivity==null)
            {
                taskdto.LastActivity = DateTime.Now;
            }

            return await repository.SubmitTask(taskdto.TaskName,taskdto.LateDays,taskdto.Salary,taskdto.LastActivity, taskdto.StatusID,taskdto.AccountID);
        }


        public async Task<object> GetTaskById(int id)
        {
            return await repository.GetTaskById(id);
        }


        public async Task<bool> SubmitAttachment(int id, IFormFile file)
        {
            return await repository.SubmitAttachment(id, file);
        }

        public async Task<List<Attachment>> GetAttachmentsByTaskId(int taskId)
        {
            return await repository.GetAttachmentsByTaskId(taskId);
        }

        public async Task<Attachment?> GetAttachmentById(int attachmentId)
        {
            return await repository.GetAttachmentById(attachmentId);
        }


        public async Task<List<Comments>> GettingComments(int id)
        {
            return await repository.GettingComments(id);
        }

        public async Task<bool> SubmitComment(int taskid, string comment)
        {
            return await repository.SubmitComment(taskid, comment);
        }

        public async Task<List<Activity>> GettingActivity(int id)
        {
            return await repository.GettingActivity(id);
        }

        public async Task<bool> ApproveStatus(int id)
        {
            return await repository.ApproveStatus(id);
        }

        public async Task<List<Meetings>> GetAllMeetingsByTaskID(int id)
        {
            return await repository.GetAllMeetingsByTaskID(id);
        }
    }
}
