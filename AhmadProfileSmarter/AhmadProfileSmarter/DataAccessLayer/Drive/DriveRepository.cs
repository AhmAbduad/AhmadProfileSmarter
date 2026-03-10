using AhmadDAL.Data;
using AhmadDAL.Models.EmployeeFiles;
using AhmadDAL.Models.ParticipantFiles;
using AhmadDAL.Models.PersonalFiles;
using AhmadProfileSmarter.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AhmadDAL.DataAccessLayer.Drive
{
    public class DriveRepository:IDrive
    {

        private readonly AppDbContext _context;

        public DriveRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ParticipantFiles>> GetAllParticipantsFiles(int id)
        {
            //return await _context.ParticipantFiles.ToListAsync();

            return await _context.ParticipantFiles
                .Where(x => x.UserID == id)
                .ToListAsync();
        }

        public async Task<bool> SaveParticipantFile(
             string ActualFileName,
             byte[] ActualFile,
             string Size,
             DateTime UploadDate, int userID, string ContentType)
        {
            var file = new ParticipantFiles
            {
                ActualFileName = ActualFileName,
                ActualFile = ActualFile,
                Size = Size,
                UploadDate = UploadDate,
                UserID = userID,
                ContentType = ContentType
            };

            await _context.ParticipantFiles.AddAsync(file);
            //return await _context.SaveChangesAsync() > 0;

            return true;
        }

        public async Task<List<PersonalFiles>> GetAllPersonalFiles(int id)
        {
            return await _context.PersonalFiles.Where(x => x.UserID == id).ToListAsync();
        }

        public async Task<bool> SavePersonalFile(
           string ActualFileName,
           byte[] ActualFile,
           string Size,
           DateTime UploadDate, int userID, string ContentType)
        {
            var file = new PersonalFiles
            {
                ActualFileName = ActualFileName,
                ActualFile = ActualFile,
                Size = Size,
                UploadDate = UploadDate,
                UserID = userID,
                ContentType = ContentType
            };

            await _context.PersonalFiles.AddAsync(file);
            //return await _context.SaveChangesAsync() > 0;

            return true;
        }


        public async Task<List<EmployeeFiles>> GetAllEmployeeFiles(int id)
        {
            return await _context.EmployeeFiles.Where(x => x.UserID == id).ToListAsync();
        }

        public async Task<bool> SaveEmployeeFiles(
          string ActualFileName,
          byte[] ActualFile,
          string Size,
          DateTime UploadDate, int userID, string ContentType)
        {
            var file = new EmployeeFiles
            {
                ActualFileName = ActualFileName,
                ActualFile = ActualFile,
                Size = Size,
                UploadDate = UploadDate,
                UserID = userID,
                ContentType = ContentType
            };

            await _context.EmployeeFiles.AddAsync(file);
            //return await _context.SaveChangesAsync() > 0;
            return true;
        }


        public async Task<ParticipantFiles?> DownloadParticipantFile(int id)
        {
            return await _context.Set<ParticipantFiles>()
                .FirstOrDefaultAsync(a => a.ParticipantFilesID == id);
        }

        public async Task<PersonalFiles?> DownloadPersonalFile(int id)
        {
            return await _context.Set<PersonalFiles>()
                .FirstOrDefaultAsync(a => a.PersonalFilesID == id);
        }

        public async Task<EmployeeFiles?> DownloadEmployeeFile(int id)
        {
            return await _context.Set<EmployeeFiles>()
                .FirstOrDefaultAsync(a => a.EmployeeFilesID == id);
        }
    }
}
