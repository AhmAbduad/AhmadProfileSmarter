using AhmadDAL.Models.Meetings;
using AhmadDAL.Models.ParticipantFiles;
using AhmadProfileSmarter.UnitofWork;

namespace AhmadProfileSmarter.Services.CollaboratedFiles
{
    public class CollaboratedFilesService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CollaboratedFilesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ParticipantFiles>> GetFilesDocx()
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                var meetings = await _unitOfWork.CollaboratedFiles.GetFilesDocx();

                await _unitOfWork.CommitTransactionAsync();
                return meetings;
            }
            catch
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }
    }
}
