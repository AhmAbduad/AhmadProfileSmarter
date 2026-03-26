using AhmadDAL.Data;
using AhmadDAL.Models.Meetings;
using AhmadDAL.Models.ParticipantFiles;
using AhmadProfileSmarter.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AhmadProfileSmarter.DataAccessLayer.CollaboratedFiles
{
    public class CollaboratedFilesRepository : ICollaboratedFiles
    {

        private readonly AppDbContext _context;

        public CollaboratedFilesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ParticipantFiles>> GetFilesDocx()
        {
            return await _context.ParticipantFiles
            .Where(f =>
                f.ContentType == "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                || (f.ActualFileName != null && f.ActualFileName.EndsWith(".docx"))
            )
            .ToListAsync();
        }

    }
}
