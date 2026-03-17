using AhmadDAL.DataAccessLayer.Drive;
using AhmadDAL.DataAccessLayer.Employees;
using AhmadDAL.Models.Credentials;
using AhmadDAL.Models.EmployeeFiles;
using AhmadDAL.Models.ParticipantFiles;
using AhmadDAL.Models.Participants;
using AhmadDAL.Models.PersonalFiles;
using AhmadProfileSmarter.Interfaces;
using AhmadProfileSmarter.UnitofWork;
using AhmadService.dto.ParticipantFile;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace AhmadService.Services.Drive
{
    public class DriveService
    {
        // private readonly IDrive repository;
        private readonly IUnitOfWork _unitOfWork;

        public DriveService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<AhmadDAL.Models.ParticipantFiles.ParticipantFiles>> GetAllParticipantsFiles()
        {
            // 🔹 Start transaction (optional for read, but consistent)
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                // 🔹 Call repository via UnitOfWork
                var files = await _unitOfWork.Drive.GetAllParticipantsFiles();

                // 🔹 Commit transaction (even for read)
                await _unitOfWork.CommitTransactionAsync();

                return files;
            }
            catch
            {
                // 🔹 Rollback if anything goes wrong
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }

        public async Task<bool> SaveParticipantFile(
             string fileName,
             byte[] fileBytes,
             string size,
             DateTime uploadDate,
             int userID,
             string ContentType
             )
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                // 🔹 Call repository via UnitOfWork
                var result = await _unitOfWork.Drive.SaveParticipantFile(fileName, fileBytes, size, uploadDate, userID, ContentType);

                // 🔹 Save changes
                await _unitOfWork.SaveChangesAsync();

                // 🔹 Commit transaction
                await _unitOfWork.CommitTransactionAsync();

                return result;
            }
            catch
            {
                // 🔹 Rollback if anything goes wrong
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }

        public async Task<List<AhmadDAL.Models.PersonalFiles.PersonalFiles>> GetAllPersonalFiles(int id)
        {
            // 🔹 Begin transaction (optional for read, but consistent)
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                // 🔹 Call repository via UnitOfWork
                var files = await _unitOfWork.Drive.GetAllPersonalFiles(id);

                // 🔹 Save changes if any (optional for read)
                await _unitOfWork.SaveChangesAsync();

                // 🔹 Commit transaction
                await _unitOfWork.CommitTransactionAsync();

                return files;
            }
            catch
            {
                // 🔹 Rollback if anything goes wrong
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }

        public async Task<bool> SavePersonalFile(
           string fileName,
           byte[] fileBytes,
           string size,
           DateTime uploadDate,
           int userID,
           string ContentType)
        {
            await _unitOfWork.BeginTransactionAsync(); // 🔹 Start transaction

            try
            {
                // 🔹 Call repository via UnitOfWork
                var result = await _unitOfWork.Drive.SavePersonalFile(fileName, fileBytes, size, uploadDate, userID, ContentType);

                // 🔹 Save changes
                await _unitOfWork.SaveChangesAsync();

                // 🔹 Commit transaction
                await _unitOfWork.CommitTransactionAsync();

                return result;
            }
            catch
            {
                // 🔹 Rollback on error
                await _unitOfWork.RollbackTransactionAsync();
                throw; // Bubble up exception
            }
        }

        public async Task<List<AhmadDAL.Models.EmployeeFiles.EmployeeFiles>> GetAllEmployeeFiles(int id)
        {
            // 🔹 Begin transaction (optional for read, but consistent)
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                // 🔹 Call repository via UnitOfWork
                var files = await _unitOfWork.Drive.GetAllEmployeeFiles(id);

                // 🔹 Commit transaction
                await _unitOfWork.CommitTransactionAsync();

                return files;
            }
            catch
            {
                // 🔹 Rollback if anything goes wrong
                await _unitOfWork.RollbackTransactionAsync();
                throw; // bubble up exception
            }
        }

        public async Task<bool> SaveEmployeeFiles(
         string fileName,
         byte[] fileBytes,
         string size,
         DateTime uploadDate,
         int userID,
         string ContentType)
        {
            // 🔹 Start transaction
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                // 🔹 Call repository via UnitOfWork
                var result = await _unitOfWork.Drive.SaveEmployeeFiles(fileName, fileBytes, size, uploadDate, userID, ContentType);

                // 🔹 Save changes
                await _unitOfWork.SaveChangesAsync();

                // 🔹 Commit transaction
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


        public async Task<ParticipantFiles?> DownloadParticipantFile(int id)
        {
            // 🔹 Start transaction
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                // 🔹 Call repository via UnitOfWork
                var result = await _unitOfWork.Drive.DownloadParticipantFile(id);

                // 🔹 Save changes
                await _unitOfWork.SaveChangesAsync();

                // 🔹 Commit transaction
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

        public async Task<PersonalFiles?> DownloadPersonalFile(int id)
        {
            // 🔹 Start transaction
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                // 🔹 Call repository via UnitOfWork
                var result = await _unitOfWork.Drive.DownloadPersonalFile(id);

                // 🔹 Save changes
                await _unitOfWork.SaveChangesAsync();

                // 🔹 Commit transaction
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

        public async Task<EmployeeFiles?> DownloadEmployeeFile(int id)
        {
            // 🔹 Start transaction
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                // 🔹 Call repository via UnitOfWork
                var result = await _unitOfWork.Drive.DownloadEmployeeFile(id);

                // 🔹 Save changes
                await _unitOfWork.SaveChangesAsync();

                // 🔹 Commit transaction
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
    }
}
