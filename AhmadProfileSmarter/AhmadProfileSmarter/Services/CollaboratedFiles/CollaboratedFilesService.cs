using AhmadDAL.Models.Meetings;
using AhmadDAL.Models.ParticipantFiles;
using AhmadProfileSmarter.dto.CollaboratedFile;
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
                var participantFiles = await _unitOfWork.CollaboratedFiles.GetFilesDocx();

                await _unitOfWork.CommitTransactionAsync();
                return participantFiles;
            }
            catch
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }

        public async Task<ParticipantFiles> UpdateFileDoc(CollaboratedFilesDto dto)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                var participantFiles = await _unitOfWork.CollaboratedFiles.UpdateFileDoc(dto.participantFilesID, dto.content);

                // Save changes
                await _unitOfWork.SaveChangesAsync();


                await _unitOfWork.CommitTransactionAsync();
                return participantFiles;
            }
            catch
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }
    }
}
