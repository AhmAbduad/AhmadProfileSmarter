using AhmadDAL.Data;
using AhmadProfileSmarter.dto.ChangeRole;
using AhmadProfileSmarter.Interfaces;
using AhmadService.dto.AdminRequests;
using AhmadService.dto.User;
using Microsoft.EntityFrameworkCore;

namespace AhmadDAL.DataAccessLayer.AdminRequests
{
    public class AdminRequestsRepository : IAdminRequests
    {
        private readonly AppDbContext _context;

        public AdminRequestsRepository(AppDbContext context)
        {
            _context = context;
        }

        //public async Task<AhmadDAL.Models.AdminRequests.AdminRequests> CreateRequest(int UserId, string RequestType, string Title, string Description, string Status, string AdminRemarks)
        //{
        //    var request = new AhmadDAL.Models.AdminRequests.AdminRequests
        //    {
        //        UserId = UserId,
        //        RequestType = RequestType,
        //        Title = Title,
        //        Description = Description,
        //        Status=Status,
        //        AdminRemarks = AdminRemarks,

        //    };

        //    _context.AdminRequests.Add(request);

        //    return request;
        //}

        //public async Task<List<AhmadDAL.Models.AdminRequests.AdminRequests>> GetAdminRequestonID(int id)
        //{
        //    return await _context.AdminRequests
        //                 .Where(x => x.UserId == id)
        //                 .OrderByDescending(x => x.CreatedAt)
        //                 .ToListAsync();
        //}


        public async Task<List<AdminUserDto>> FetchUsers()
        {
            var result = await _context.Users
           .Include(u => u.Role)
           .Select(u => new AdminUserDto
           {
               UserId = u.UserId,
               UserName = u.UserName,
               RoleName = u.Role.RoleName,
               Email=u.Email,
               RoleID = u.RoleID
           })
           .ToListAsync();

            return result;

            // return await _context.Users.ToListAsync();
        }

        public async Task<List<AhmadProfileSmarter.Models.Roles.Roles>> FetchRoles()
        {
            return await _context.Roles.ToListAsync();

        }

        public async Task<bool> ChangeRole(int userid, ChangeRoleDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userid);

            if (user == null)
            {
                return false;
            }

            user.RoleID = dto.roleId;

            return true;
        }
    }
}