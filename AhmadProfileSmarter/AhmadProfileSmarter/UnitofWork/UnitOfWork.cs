using AhmadDAL.Data;
using AhmadDAL.DataAccessLayer.AdminRequests;
using AhmadDAL.DataAccessLayer.Chats;
using AhmadDAL.DataAccessLayer.Credentials;
using AhmadDAL.DataAccessLayer.Dashboard;
using AhmadDAL.DataAccessLayer.Drive;
using AhmadDAL.DataAccessLayer.Employees;
using AhmadDAL.DataAccessLayer.MeetingsVideo;
using AhmadDAL.DataAccessLayer.Profile;
using AhmadDAL.DataAccessLayer.Register;
using AhmadDAL.DataAccessLayer.ReportBug;
using AhmadDAL.DataAccessLayer.Tasks;
using AhmadProfileSmarter.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace AhmadProfileSmarter.UnitofWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        private IDbContextTransaction _transaction;
        public IAdminRequests AdminRequests { get; }
        public IChats Chats { get; }
        public IDashboard Dashboard { get; }
        public IDrive Drive { get; }
        public IEmployee Employee { get; }
        public ILogin Login { get; }
        public IMeetingsVideo MeetingsVideo { get; }
        public IProfile Profile { get; }
        public IRegister Register { get; }
        public IReportBug ReportBug { get; }
        public ITasks Tasks { get; }
        public ICollaboratedFiles CollaboratedFiles { get; }


        //public UnitOfWork(AppDbContext context)
        //{
        //    _context = context;
        //    AdminRequests = new AdminRequestsRepository(_context);
        //    Chats = new ChatsRepository(_context);
        //    Dashboard = new DashboardRepository(_context);
        //    Drive = new DriveRepository(_context);
        //    Employee = new EmployeesRepository(_context);
        //    Login = new LoginRepository(context);
        //    MeetingsVideo = new MeetingsVideoRepository(_context);
        //    Profile = new ProfileRepository(context);
        //    Register = new RegisterRepository(context);
        //    ReportBug = new ReportbugRepository(context);
        //    Tasks = new TasksRepository(context);
        //}


        // this is unit of work constructor
        public UnitOfWork(
                        AppDbContext context,
                        IAdminRequests adminRequests,
                        IChats chats,
                        IDashboard dashboard,
                        IDrive drive,
                        IEmployee employee,
                        ILogin login,
                        IMeetingsVideo meetingsVideo,
                        IProfile profile,
                        IRegister register,
                        IReportBug reportBug,
                        ITasks tasks,
                        ICollaboratedFiles collaboratedFiles)
            {
                _context = context;

                AdminRequests = adminRequests;
                Chats = chats;
                Dashboard = dashboard;
                Drive = drive;
                Employee = employee;
                Login = login;
                MeetingsVideo = meetingsVideo;
                Profile = profile;
                Register = register;
                ReportBug = reportBug;
                Tasks = tasks;
                CollaboratedFiles = collaboratedFiles;
            }



        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            //await _transaction.CommitAsync();

            if (_transaction != null)
                await _transaction.CommitAsync();
        }

        public async Task RollbackTransactionAsync()
        {
            // await _transaction.RollbackAsync();
            if (_transaction != null)
                await _transaction.RollbackAsync();
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _context?.Dispose();
        }
    }
}
