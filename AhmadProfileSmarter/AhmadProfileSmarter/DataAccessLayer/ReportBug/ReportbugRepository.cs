using AhmadDAL.Data;
using AhmadDAL.Models.Reportbug;
using AhmadProfileSmarter.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AhmadDAL.DataAccessLayer.ReportBug
{
    public class ReportbugRepository:IReportBug
    {
        private readonly AppDbContext _context;

        public ReportbugRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> SubmitReportbug(string Title,string Description, IFormFile fileimage,int UserId)
        {
           byte[]? fileBytes = null;

            if (fileimage != null)
            {
                using var ms = new MemoryStream();
                await fileimage.CopyToAsync(ms);
                fileBytes = ms.ToArray();
            }

            var bug = new Reportbug
            {
                UserId= UserId,
                title = Title,
                description = Description,
                attachment = fileBytes
            };

            await _context.Reportbugs.AddAsync(bug);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Reportbug>> GetAllBugs()
        {
            return await _context.Reportbugs.ToListAsync();
        }
    }
}
