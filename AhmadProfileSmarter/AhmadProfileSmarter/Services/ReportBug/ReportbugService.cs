using AhmadDAL.DataAccessLayer.Credentials;
using AhmadDAL.DataAccessLayer.ReportBug;
using AhmadDAL.Models.Reportbug;
using AhmadProfileSmarter.Interfaces;
using AhmadService.dto.Credentials;
using AhmadService.dto.Reportbug;

namespace AhmadService.Services.ReportBug
{
    public class ReportbugService
    {
        private readonly IReportBug repository;

        public ReportbugService(IReportBug repository)
        {

            this.repository = repository;
        }

        public async Task<bool> SubmitReportbug(ReportbugDto reportbugDto)
        {
            var user = await repository.SubmitReportbug(reportbugDto.title, reportbugDto.description,reportbugDto.attachment,reportbugDto.UserId);
            return user != false;
        }

        public async Task<List<Reportbug>> GetAllBugs()
        {
            return await repository.GetAllBugs();
        }
    }
}