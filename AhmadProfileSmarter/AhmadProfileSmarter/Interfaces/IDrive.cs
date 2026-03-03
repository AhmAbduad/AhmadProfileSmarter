using AhmadDAL.Models.EmployeeFiles;
using AhmadDAL.Models.ParticipantFiles;
using AhmadDAL.Models.PersonalFiles;

namespace AhmadProfileSmarter.Interfaces
{
    public interface IDrive
    {
        Task<List<ParticipantFiles>> GetAllParticipantsFiles();

        Task<bool> SaveParticipantFile(string ActualFileName, byte[] ActualFile, string Size, DateTime UploadDate);

        Task<List<PersonalFiles>> GetAllPersonalFiles();

        Task<bool> SavePersonalFile(string ActualFileName, byte[] ActualFile, string Size, DateTime UploadDate);

        Task<List<EmployeeFiles>> GetAllEmployeeFiles();

        Task<bool> SaveEmployeeFiles(string ActualFileName, byte[] ActualFile, string Size, DateTime UploadDate);
    }
}
