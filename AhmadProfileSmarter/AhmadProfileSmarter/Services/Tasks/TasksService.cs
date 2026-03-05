using AhmadDAL.DataAccessLayer.Tasks;
using AhmadDAL.Models.Activity;
using AhmadDAL.Models.Attachment;
using AhmadDAL.Models.Comments;
using AhmadDAL.Models.Meetings;
using AhmadDAL.Models.Status;
using AhmadProfileSmarter.Interfaces;
using AhmadProfileSmarter.UnitofWork;
using AhmadService.dto.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace AhmadService.Services.Tasks
{
    public class TasksService
    {
        //private readonly ITasks repository;

        private readonly IUnitOfWork _unitOfWork;

        public TasksService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<object> GetAllTasks()
        {
            //return await repository.GetAllTasks();
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                
                var tasks = await _unitOfWork.Tasks.GetAllTasks();

                await _unitOfWork.CommitTransactionAsync();

                return tasks;
            }
            catch (Exception)
            {
                // ✅ Rollback if anything goes wrong
                await _unitOfWork.RollbackTransactionAsync();
                throw; // bubble up the exception
            }
        }

        public async Task<List<AhmadDAL.Models.Status.Status>> GetAllStatus()
        {
            // ✅ Begin transaction (optional for read-only, but consistent)
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                // ✅ Call repository via UnitOfWork
                var statuses = await _unitOfWork.Tasks.GetAllStatus();

                // ✅ Commit transaction (even for read)
                await _unitOfWork.CommitTransactionAsync();

                return statuses;
            }
            catch (Exception)
            {
                // ✅ Rollback if something goes wrong
                await _unitOfWork.RollbackTransactionAsync();
                throw; // bubble up the exception
            }
        }

        public async Task<List<AhmadDAL.Models.Account.Account>> GetAllAccounts()
        {
            //return await repository.GetAllAccounts();

            // 🔹 Begin transaction
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                // 🔹 Call repository via UnitOfWork
                var accounts = await _unitOfWork.Tasks.GetAllAccounts();

                // 🔹 Commit transaction
                await _unitOfWork.CommitTransactionAsync();

                return accounts;
            }
            catch (Exception)
            {
                // 🔹 Rollback if anything goes wrong
                await _unitOfWork.RollbackTransactionAsync();
                throw; // Bubble up the exception
            }
        }

        public async Task<bool> SubmitTask(TasksDto taskdto)
        {
            if (taskdto.LastActivity == null)
                taskdto.LastActivity = DateTime.Now;

            await _unitOfWork.BeginTransactionAsync(); // 🔹 Start transaction

            try
            {
                // 🔹 Call repository via UnitOfWork
                var result = await _unitOfWork.Tasks.SubmitTask(
                    taskdto.TaskName,
                    taskdto.LateDays,
                    taskdto.Salary,
                    taskdto.LastActivity,
                    taskdto.StatusID,
                    taskdto.AccountID
                );

                // ✅ Commit all changes here
                await _unitOfWork.SaveChangesAsync();

                await _unitOfWork.CommitTransactionAsync(); // 🔹 Commit if success
                return result;
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransactionAsync(); // 🔹 Rollback on error
                throw; // Bubble up exception
            }
        }


        public async Task<object> GetTaskById(int id)
        {
            await _unitOfWork.BeginTransactionAsync(); // start transaction

            try
            {
                // Call repository via UnitOfWork
                var task = await _unitOfWork.Tasks.GetTaskById(id);

               
                await _unitOfWork.CommitTransactionAsync();

                return task;
            }
            catch
            {
                // Rollback in case of error
                await _unitOfWork.RollbackTransactionAsync();
                throw; // bubble up the exception
            }
        }


        public async Task<bool> SubmitAttachment(int id, IFormFile file)
        {
            // ✅ Start a transaction
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                // 🔹 Call repository via UnitOfWork
                var result = await _unitOfWork.Tasks.SubmitAttachment(id, file);

                // ✅ Save changes and commit transaction
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransactionAsync();

                return result;
            }
            catch
            {
                // 🔹 Rollback on error
                await _unitOfWork.RollbackTransactionAsync();
                throw; // bubble up exception
            }
        }

        public async Task<List<Attachment>> GetAttachmentsByTaskId(int taskId)
        {
            await _unitOfWork.BeginTransactionAsync(); // Start transaction

            try
            {
                // Call repository via UnitOfWork
                var attachments = await _unitOfWork.Tasks.GetAttachmentsByTaskId(taskId);

              

                await _unitOfWork.CommitTransactionAsync(); // Commit transaction
                return attachments;
            }
            catch
            {
                await _unitOfWork.RollbackTransactionAsync(); // Rollback on error
                throw; // bubble up exception
            }
        }

        public async Task<Attachment?> GetAttachmentById(int attachmentId)
        {
            await _unitOfWork.BeginTransactionAsync(); // Start transaction

            try
            {
                // Call repository via UnitOfWork
                var attachment = await _unitOfWork.Tasks.GetAttachmentById(attachmentId);

                await _unitOfWork.CommitTransactionAsync(); // Commit transaction
                return attachment;
            }
            catch
            {
                await _unitOfWork.RollbackTransactionAsync(); // Rollback if something goes wrong
                throw; // Bubble up the exception
            }
        }


        public async Task<List<Comments>> GettingComments(int id)
        {
            await _unitOfWork.BeginTransactionAsync(); // Start transaction

            try
            {
                // Call repository via UnitOfWork
                var comments = await _unitOfWork.Tasks.GettingComments(id);


                await _unitOfWork.CommitTransactionAsync(); // Commit transaction
                return comments;
            }
            catch
            {
                await _unitOfWork.RollbackTransactionAsync(); // Rollback if something goes wrong
                throw; // Bubble up exception
            }
        }

        public async Task<bool> SubmitComment(int taskid, string comment)
        {
            await _unitOfWork.BeginTransactionAsync(); // Start transaction

            try
            {
                // Call repository via UnitOfWork
                var result = await _unitOfWork.Tasks.SubmitComment(taskid, comment);

                // Save changes
                await _unitOfWork.SaveChangesAsync();

                await _unitOfWork.CommitTransactionAsync(); // Commit transaction
                return result;
            }
            catch
            {
                await _unitOfWork.RollbackTransactionAsync(); // Rollback on error
                throw; // Bubble up exception
            }
        }

        public async Task<List<Activity>> GettingActivity(int id)
        {
            await _unitOfWork.BeginTransactionAsync(); // Start transaction

            try
            {
                // Call repository via UnitOfWork
                var activities = await _unitOfWork.Tasks.GettingActivity(id);


                await _unitOfWork.CommitTransactionAsync(); // Commit transaction
                return activities;
            }
            catch
            {
                await _unitOfWork.RollbackTransactionAsync(); // Rollback on error
                throw; // Bubble up exception
            }
        }

        public async Task<bool> ApproveStatus(int id)
        {
            await _unitOfWork.BeginTransactionAsync(); // Start transaction

            try
            {
                // Call repository via UnitOfWork
                var result = await _unitOfWork.Tasks.ApproveStatus(id);

                // Save changes
                await _unitOfWork.SaveChangesAsync();

                await _unitOfWork.CommitTransactionAsync(); // Commit transaction
                return result;
            }
            catch
            {
                await _unitOfWork.RollbackTransactionAsync(); // Rollback on error
                throw; // Bubble up exception
            }
        }

        public async Task<List<Meetings>> GetAllMeetingsByTaskID(int id)
        {
            // 🔹 Begin transaction (optional for read, but keeps pattern consistent)
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                // 🔹 Call repository via UnitOfWork
                var meetings = await _unitOfWork.Tasks.GetAllMeetingsByTaskID(id);

             

                // 🔹 Commit transaction
                await _unitOfWork.CommitTransactionAsync();

                return meetings;
            }
            catch
            {
                // 🔹 Rollback on error
                await _unitOfWork.RollbackTransactionAsync();
                throw; // bubble up the exception
            }
        }
    }
}
