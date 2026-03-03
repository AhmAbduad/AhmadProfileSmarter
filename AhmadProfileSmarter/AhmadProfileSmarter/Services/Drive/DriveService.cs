using AhmadDAL.DataAccessLayer.Drive;
using AhmadDAL.DataAccessLayer.Employees;
using AhmadDAL.Models.Participants;
using AhmadProfileSmarter.Interfaces;
using AhmadService.dto.ParticipantFile;

namespace AhmadService.Services.Drive
{
    public class DriveService
    {
        private readonly IDrive repository;

        public DriveService(IDrive repository)
        {

            this.repository = repository;
        }

        public async Task<List<AhmadDAL.Models.ParticipantFiles.ParticipantFiles>> GetAllParticipantsFiles()
        {
            return await repository.GetAllParticipantsFiles();
        }

        public async Task<bool> SaveParticipantFile(
             string fileName,
             byte[] fileBytes,
             string size,
             DateTime uploadDate)
        {
            return await repository.SaveParticipantFile(fileName, fileBytes, size, uploadDate);
        }

        public async Task<List<AhmadDAL.Models.PersonalFiles.PersonalFiles>> GetAllPersonalFiles()
        {
            return await repository.GetAllPersonalFiles();
        }

        public async Task<bool> SavePersonalFile(
           string fileName,
           byte[] fileBytes,
           string size,
           DateTime uploadDate)
        {
            return await repository.SavePersonalFile(fileName, fileBytes, size, uploadDate);
        }

        public async Task<List<AhmadDAL.Models.EmployeeFiles.EmployeeFiles>> GetAllEmployeeFiles()
        {
            return await repository.GetAllEmployeeFiles();
        }

        public async Task<bool> SaveEmployeeFiles(
         string fileName,
         byte[] fileBytes,
         string size,
         DateTime uploadDate)
        {
            return await repository.SaveEmployeeFiles(fileName, fileBytes, size, uploadDate);
        }
        
    }
}
