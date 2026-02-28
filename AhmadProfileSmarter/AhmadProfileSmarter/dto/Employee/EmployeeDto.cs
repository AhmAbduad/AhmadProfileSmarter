using AhmadService.dto.Participant;
using AhmadService.dto.User;

namespace AhmadService.dto.Employee
{
    public class EmployeeDto
    {
        public int EmployeeID { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string? Designation { get; set; }

        public decimal Salary { get; set; }

        public DateTime JoinDate { get; set; }


        public UserDto? User { get; set; }


        public List<ParticipantDto> Participants { get; set; } = new();
    }
}
