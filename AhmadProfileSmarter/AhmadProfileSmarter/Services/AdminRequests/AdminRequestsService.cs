using AhmadDAL.DataAccessLayer.AdminRequests;
using AhmadDAL.DataAccessLayer.Dashboard;
using AhmadService.dto.AdminRequests;

namespace AhmadService.Services.AdminRequests
{
    public class AdminRequestsService
    {
        private readonly AdminRequestsRepository repository;

        public AdminRequestsService(AdminRequestsRepository repository)
        {
            this.repository = repository;
        }

        public async Task<AhmadDAL.Models.AdminRequests.AdminRequests> CreateRequest(CreateRequestDto dto)
        {
            return await repository.CreateRequest(dto.UserId,dto.RequestType,dto.Title,dto.Description,dto.Status,dto.AdminRemarks);
        }

        public async Task<List<AhmadDAL.Models.AdminRequests.AdminRequests>> GetAdminRequestonID(int id)
        {
            return await repository.GetAdminRequestonID(id);
        }
    }
}
