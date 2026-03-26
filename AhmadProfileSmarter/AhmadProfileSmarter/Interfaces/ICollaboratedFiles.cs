using AhmadDAL.Models.Credentials;
using AhmadDAL.Models.ParticipantFiles;

namespace AhmadProfileSmarter.Interfaces
{
    public interface ICollaboratedFiles
    {
        Task<List<ParticipantFiles>> GetFilesDocx();
    }
}
