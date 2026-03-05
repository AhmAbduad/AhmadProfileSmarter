using AhmadDAL.DataAccessLayer.Employees;
using AhmadDAL.DataAccessLayer.Tasks;
using AhmadDAL.Models.Employees;
using AhmadProfileSmarter.Interfaces;
using AhmadProfileSmarter.UnitofWork;
using AhmadService.dto.Employee;
using AhmadService.dto.Participant;
using AhmadService.dto.User;

namespace AhmadService.Services.Employees
{
    public class EmployeesService
    {
        //private readonly IEmployee repository;
        // private readonly IDrive repository;
        private readonly IUnitOfWork _unitOfWork;

        public EmployeesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<EmployeeDto>> GetAllEmployees()
        {
            // 🔹 Begin transaction (optional for read, but consistent)
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                // 🔹 Call repository via UnitOfWork
                var employees = await _unitOfWork.Employee.GetAllEmployees();

                // 🔹 Commit transaction (even for read)
                await _unitOfWork.CommitTransactionAsync();

                // 🔹 Map to DTO
                var result = employees.Select(e => new EmployeeDto
                {
                    EmployeeID = e.EmployeeID,
                    Designation = e.Designation,
                    Salary = e.Salary,
                    JoinDate = e.JoinDate,

                    User = new UserDto
                    {
                        UserId = e.User!.UserId,
                        UserName = e.User.UserName,
                        Email = e.User.Email
                    },

                    Participants = e.Participants.Select(p => new ParticipantDto
                    {
                        ParticipantID = p.ParticipantID,
                        ParticipantName = p.ParticipantName
                    }).ToList()

                }).ToList();

                return result;
            }
            catch
            {
                // 🔹 Rollback on error
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }
    }
}
