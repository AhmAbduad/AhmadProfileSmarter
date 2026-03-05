using AhmadDAL.DataAccessLayer.Credentials;
using AhmadDAL.DataAccessLayer.ReportBug;
using AhmadDAL.Models.Reportbug;
using AhmadProfileSmarter.Interfaces;
using AhmadProfileSmarter.UnitofWork;
using AhmadService.dto.Credentials;
using AhmadService.dto.Reportbug;

namespace AhmadService.Services.ReportBug
{
    public class ReportbugService
    {
       // private readonly IReportBug repository;
        private readonly IUnitOfWork _unitOfWork;

        public ReportbugService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> SubmitReportbug(ReportbugDto reportbugDto)
        {
            await _unitOfWork.BeginTransactionAsync(); // Start transaction

            try
            {
                var result = await _unitOfWork.ReportBug.SubmitReportbug(
                    reportbugDto.title,
                    reportbugDto.description,
                    reportbugDto.attachment,
                    reportbugDto.UserId
                );

                await _unitOfWork.SaveChangesAsync(); // Save changes

                await _unitOfWork.CommitTransactionAsync(); // Commit transaction

                return result != false;
            }
            catch
            {
                await _unitOfWork.RollbackTransactionAsync(); // Rollback if error
                throw;
            }
        }

        public async Task<List<Reportbug>> GetAllBugs()
        {
            await _unitOfWork.BeginTransactionAsync(); // Start transaction

            try
            {
                var bugs = await _unitOfWork.ReportBug.GetAllBugs();

                await _unitOfWork.CommitTransactionAsync(); // Commit transaction

                return bugs;
            }
            catch
            {
                await _unitOfWork.RollbackTransactionAsync(); // Rollback if error
                throw;
            }
        }
    }
}