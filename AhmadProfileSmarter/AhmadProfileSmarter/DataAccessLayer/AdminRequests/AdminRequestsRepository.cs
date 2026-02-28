using AhmadDAL.Data;
using Microsoft.EntityFrameworkCore;

namespace AhmadDAL.DataAccessLayer.AdminRequests
{
    public class AdminRequestsRepository
    {
        private readonly AppDbContext _context;

        public AdminRequestsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<AhmadDAL.Models.AdminRequests.AdminRequests> CreateRequest(int UserId, string RequestType, string Title, string Description, string Status, string AdminRemarks)
        {
            var request = new AhmadDAL.Models.AdminRequests.AdminRequests
            {
                UserId = UserId,
                RequestType = RequestType,
                Title = Title,
                Description = Description,
                Status=Status,
                AdminRemarks = AdminRemarks,

            };

            _context.AdminRequests.Add(request);
            await _context.SaveChangesAsync();

            return request;
        }
        
        public async Task<List<AhmadDAL.Models.AdminRequests.AdminRequests>> GetAdminRequestonID(int id)
        {
            return await _context.AdminRequests
                         .Where(x => x.UserId == id)
                         .OrderByDescending(x => x.CreatedAt)
                         .ToListAsync();
        }
    }
}
