using AhmadDAL.Data;
using AhmadDAL.Models.Activity;
using AhmadDAL.Models.Attachment;
using AhmadDAL.Models.Comments;
using AhmadDAL.Models.Meetings;
using AhmadDAL.Models.Reportbug;
using AhmadDAL.Models.Status;
using AhmadProfileSmarter.Interfaces;
using AhmadProfileSmarter.UnitofWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;



namespace AhmadDAL.DataAccessLayer.Tasks
{
    public class TasksRepository :ITasks
    {
        private readonly AppDbContext _context;

        public TasksRepository(AppDbContext context)
        {
              _context= context;
        }

        public async Task<object> GetAllTasks()
        {
            var data = await _context.Tasks
                .Include(t => t.Status)
                .Include(t => t.Account)
                //.Include(t => t.Files)
                .Select(t => new
                {
                    t.TaskID,
                    t.TaskName,
                    t.LateDays,
                    t.Salary,
                    t.LastActivity,

                    StatusName = t.Status.StatusName,
                    AccountName = t.Account.AccountName,

                    //FileName = t.Files.FileName
                })
                .ToListAsync();

            return data;
        }


        public async Task<List<AhmadDAL.Models.Status.Status>> GetAllStatus()
        {
            return await _context.Statuses.ToListAsync();
        }

        public async Task<List<AhmadDAL.Models.Account.Account>> GetAllAccounts()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task<bool> SubmitTask(string TaskName, string LateDays, string Salary, DateTime LastActivity, int StatusID, int AccountID)
        {
            var TaskDTO = new AhmadDAL.Models.Tasks.Tasks
            {
                TaskName = TaskName,
                LateDays = LateDays,
                Salary = Salary,
                LastActivity = LastActivity,
                StatusID = StatusID,
                AccountID = AccountID,
                //FilesID=1
            };

            await _context.Tasks.AddAsync(TaskDTO);

            return true;
        }


        public async Task<object?> GetTaskById(int id)
        {
            var data = await _context.Tasks
                .Where(t => t.TaskID == id)
                .Select(t => new
                {
                    t.TaskID,
                    t.TaskName,
                    t.LateDays,
                    t.Salary,
                    t.LastActivity,

                    StatusName = t.Status != null ? t.Status.StatusName : "",
                    AccountName = t.Account != null ? t.Account.AccountName : "",

                    Attachments = t.Attachments.Select(a => new
                    {
                        a.AttachmentID,
                        a.Size,
                        a.UploadDate
                    }).ToList(),

                    Meetings = t.Meetings.Select(m => new
                    {
                        m.MeetingID,
                        m.Title,
                        m.Description,
                        m.StartTime,
                        m.EndTime,
                        m.MeetingLink,
                        m.CreatedAt,
                        m.UpdatedAt,
                        m.IsDeleted
                    }).ToList(),

                    Activities = t.Activity.Select(a => new
                    {
                        a.ActivityID,
                        a.ActivityText
                    }).ToList(),

                    Comments = t.Comments.Select(c => new
                    {
                        c.CommentsID,
                        c.CommentsText
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            return data;
        }



        public async Task<bool> SubmitAttachment(int id, IFormFile formFile)
        {
            if (formFile == null || formFile.Length == 0)
                return false;

            // ✅ Check task exists
            var taskExists = await _context.Tasks.AnyAsync(t => t.TaskID == id);
            if (!taskExists)
                return false;

            byte[] fileBytes;

            // ✅ Convert file to byte[]
            using (var ms = new MemoryStream())
            {
                await formFile.CopyToAsync(ms);
                fileBytes = ms.ToArray();
            }

            // ✅ Create attachment entity
            var attachment = new AhmadDAL.Models.Attachment.Attachment
            {
                TaskID = id,
                AttachmentFile = fileBytes,
                FileName = formFile.FileName,
                ContentType = formFile.ContentType,
                Size = $"{formFile.Length / 1024} KB",
                UploadDate = DateTime.Now
            };
            
            await _context.Attachments.AddAsync(attachment);

            return true;
        }
        public async Task<List<Attachment>> GetAttachmentsByTaskId(int taskId)
        {
            return await _context.Set<Attachment>()
                .Where(a => a.TaskID == taskId)
                .OrderByDescending(a => a.UploadDate)
                .ToListAsync();
        }

        // 🔹 Get single attachment (WITH FILE DATA)
        public async Task<Attachment?> GetAttachmentById(int attachmentId)
        {
            return await _context.Set<Attachment>()
                .FirstOrDefaultAsync(a => a.AttachmentID == attachmentId);
        }

        public async Task<List<Comments>> GettingComments(int id)
        {
            return await _context.Comments
            .Where(c => c.TaskID == id)
            .ToListAsync();
        }

        public async Task<bool> SubmitComment(int taskid, string comment)
        {
            if(taskid<=0 || string.IsNullOrEmpty(comment))
            {
                return false;
            }

            var savingcomment = new Comments
            {
                TaskID = taskid,
                CommentsText = comment
            };

            await _context.Comments.AddAsync(savingcomment);
         

            return true;
        }

        public async Task<List<Activity>> GettingActivity(int id)
        {
            return await _context.Activities.Where(c=>c.TaskID==id).ToListAsync();
        }

        public async Task<bool> ApproveStatus(int id)
        {
            // 1️⃣ Find task
            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.TaskID == id);

            if (task == null)
                return false;

            // 2️⃣ Get StatusID for "Completed"
            var completedStatus = await _context.Statuses
                .FirstOrDefaultAsync(s => s.StatusName == "Completed");

            if (completedStatus == null)
                return false;

            // 3️⃣ Update task status
            task.StatusID = completedStatus.StatusID;

            return true;
        }

        public async Task<List<Meetings>> GetAllMeetingsByTaskID(int id)
        {
            return await _context.Meetings
           .Where(c => c.TaskID == id)
           .ToListAsync();
        }
    }
}
