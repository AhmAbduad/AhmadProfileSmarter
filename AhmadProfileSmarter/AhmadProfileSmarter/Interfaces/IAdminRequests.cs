using AhmadProfileSmarter.dto.ChangeRole;
using AhmadService.dto.AdminRequests;

namespace AhmadProfileSmarter.Interfaces
{
    public interface IAdminRequests
    {
        //Task<AhmadDAL.Models.AdminRequests.AdminRequests> CreateRequest(int UserId, string RequestType, string Title, string Description, string Status, string AdminRemarks);

        //Task<List<AhmadDAL.Models.AdminRequests.AdminRequests>> GetAdminRequestonID(int id);


        Task<List<AdminUserDto>> FetchUsers();

        Task<List<AhmadProfileSmarter.Models.Roles.Roles>> FetchRoles();

        Task<bool> ChangeRole(int userid, ChangeRoleDto dto);
    }
}
