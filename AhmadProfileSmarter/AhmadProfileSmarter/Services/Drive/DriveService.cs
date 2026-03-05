using AhmadDAL.DataAccessLayer.Drive;
using AhmadDAL.DataAccessLayer.Employees;
using AhmadDAL.Models.Participants;
using AhmadProfileSmarter.Interfaces;
using AhmadProfileSmarter.UnitofWork;
using AhmadService.dto.ParticipantFile;

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
             DateTime uploadDate)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                // 🔹 Call repository via UnitOfWork
                var result = await _unitOfWork.Drive.SaveParticipantFile(fileName, fileBytes, size, uploadDate);

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

        public async Task<List<AhmadDAL.Models.PersonalFiles.PersonalFiles>> GetAllPersonalFiles()
        {
            // 🔹 Begin transaction (optional for read, but consistent)
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                // 🔹 Call repository via UnitOfWork
                var files = await _unitOfWork.Drive.GetAllPersonalFiles();

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
           DateTime uploadDate)
        {
            await _unitOfWork.BeginTransactionAsync(); // 🔹 Start transaction

            try
            {
                // 🔹 Call repository via UnitOfWork
                var result = await _unitOfWork.Drive.SavePersonalFile(fileName, fileBytes, size, uploadDate);

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

        public async Task<List<AhmadDAL.Models.EmployeeFiles.EmployeeFiles>> GetAllEmployeeFiles()
        {
            // 🔹 Begin transaction (optional for read, but consistent)
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                // 🔹 Call repository via UnitOfWork
                var files = await _unitOfWork.Drive.GetAllEmployeeFiles();

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
         DateTime uploadDate)
        {
            // 🔹 Start transaction
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                // 🔹 Call repository via UnitOfWork
                var result = await _unitOfWork.Drive.SaveEmployeeFiles(fileName, fileBytes, size, uploadDate);

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
