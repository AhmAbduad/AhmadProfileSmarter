using AhmadDAL.Models.Employees;

namespace AhmadProfileSmarter.Interfaces
{
    public interface IEmployee
    {
        Task<List<Employee>> GetAllEmployees();
    }
}
