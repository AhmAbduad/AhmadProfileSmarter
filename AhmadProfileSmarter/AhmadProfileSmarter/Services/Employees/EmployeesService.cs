using AhmadDAL.DataAccessLayer.Employees;
using AhmadDAL.DataAccessLayer.Tasks;
using AhmadDAL.Models.Employees;
using AhmadProfileSmarter.Interfaces;
using AhmadService.dto.Employee;
using AhmadService.dto.Participant;
using AhmadService.dto.User;

namespace AhmadService.Services.Employees
{
    public class EmployeesService
    {
        private readonly IEmployee repository;

        public EmployeesService(IEmployee repository)
        {

            this.repository = repository;
        }

        public async Task<List<EmployeeDto>> GetAllEmployees()
        {
            var employees = await repository.GetAllEmployees();

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
    }
}
