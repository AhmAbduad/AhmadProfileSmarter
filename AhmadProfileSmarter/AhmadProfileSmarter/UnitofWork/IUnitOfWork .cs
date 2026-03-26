using AhmadProfileSmarter.Interfaces;

namespace AhmadProfileSmarter.UnitofWork
{
    public interface IUnitOfWork:IDisposable
    {
        IAdminRequests AdminRequests { get; }
        IChats Chats { get; }
        IDashboard Dashboard { get; }
        IDrive Drive { get; }
        IEmployee Employee { get; }
        ILogin Login { get; }
        IMeetingsVideo MeetingsVideo { get; }
        IProfile Profile { get; }
        IRegister Register { get; }
        IReportBug ReportBug { get; }
        ITasks Tasks { get; }
        ICollaboratedFiles CollaboratedFiles { get; }

        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();

    }
}
