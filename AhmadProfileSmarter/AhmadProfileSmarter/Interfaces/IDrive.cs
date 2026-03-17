using AhmadDAL.Models.Credentials;
using AhmadDAL.Models.EmployeeFiles;
using AhmadDAL.Models.ParticipantFiles;
using AhmadDAL.Models.PersonalFiles;

namespace AhmadProfileSmarter.Interfaces
{
    public interface IDrive
    {
        Task<List<ParticipantFiles>> GetAllParticipantsFiles();

        Task<bool> SaveParticipantFile(string ActualFileName, byte[] ActualFile, string Size, DateTime UploadDate,int userID, string ContentType);

        Task<List<PersonalFiles>> GetAllPersonalFiles(int id);

        Task<bool> SavePersonalFile(string ActualFileName, byte[] ActualFile, string Size, DateTime UploadDate, int userID, string ContentType);

        Task<List<EmployeeFiles>> GetAllEmployeeFiles(int id);

        Task<bool> SaveEmployeeFiles(string ActualFileName, byte[] ActualFile, string Size, DateTime UploadDate, int userID, string ContentType);

        Task<ParticipantFiles?> DownloadParticipantFile(int id);

        Task<PersonalFiles?> DownloadPersonalFile(int id);

        Task<EmployeeFiles?> DownloadEmployeeFile(int id);
    }
}
