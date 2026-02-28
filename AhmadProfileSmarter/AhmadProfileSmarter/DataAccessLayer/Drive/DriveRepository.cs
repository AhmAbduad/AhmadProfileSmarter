using AhmadDAL.Data;
using AhmadDAL.Models.EmployeeFiles;
using AhmadDAL.Models.ParticipantFiles;
using AhmadDAL.Models.PersonalFiles;
using Microsoft.EntityFrameworkCore;

namespace AhmadDAL.DataAccessLayer.Drive
{
    public class DriveRepository
    {

        private readonly AppDbContext _context;

        public DriveRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ParticipantFiles>> GetAllParticipantsFiles()
        {
            return await _context.ParticipantFiles.ToListAsync();
        }

        public async Task<bool> SaveParticipantFile(
             string ActualFileName,
             byte[] ActualFile,
             string Size,
             DateTime UploadDate)
        {
            var file = new ParticipantFiles
            {
                ActualFileName = ActualFileName,
                ActualFile = ActualFile,
                Size = Size,
                UploadDate = UploadDate
            };

            await _context.ParticipantFiles.AddAsync(file);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<PersonalFiles>> GetAllPersonalFiles()
        {
            return await _context.PersonalFiles.ToListAsync();
        }

        public async Task<bool> SavePersonalFile(
           string ActualFileName,
           byte[] ActualFile,
           string Size,
           DateTime UploadDate)
        {
            var file = new PersonalFiles
            {
                ActualFileName = ActualFileName,
                ActualFile = ActualFile,
                Size = Size,
                UploadDate = UploadDate
            };

            await _context.PersonalFiles.AddAsync(file);
            return await _context.SaveChangesAsync() > 0;
        }


        public async Task<List<EmployeeFiles>> GetAllEmployeeFiles()
        {
            return await _context.EmployeeFiles.ToListAsync();
        }

        public async Task<bool> SaveEmployeeFiles(
          string ActualFileName,
          byte[] ActualFile,
          string Size,
          DateTime UploadDate)
        {
            var file = new EmployeeFiles
            {
                ActualFileName = ActualFileName,
                ActualFile = ActualFile,
                Size = Size,
                UploadDate = UploadDate
            };

            await _context.EmployeeFiles.AddAsync(file);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
