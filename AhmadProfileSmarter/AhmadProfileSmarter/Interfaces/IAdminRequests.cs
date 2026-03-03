namespace AhmadProfileSmarter.Interfaces
{
    public interface IAdminRequests
    {
        Task<AhmadDAL.Models.AdminRequests.AdminRequests> CreateRequest(int UserId, string RequestType, string Title, string Description, string Status, string AdminRemarks);

        Task<List<AhmadDAL.Models.AdminRequests.AdminRequests>> GetAdminRequestonID(int id);
    }
}
