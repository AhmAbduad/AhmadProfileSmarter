using AhmadDAL.Models.Reportbug;

namespace AhmadProfileSmarter.Interfaces
{
    public interface IReportBug
    {
        Task<bool> SubmitReportbug(string Title, string Description, IFormFile fileimage, int UserId);

        Task<List<Reportbug>> GetAllBugs();
    }
}
