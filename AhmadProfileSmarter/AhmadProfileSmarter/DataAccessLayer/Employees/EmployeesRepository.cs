using AhmadDAL.Data;
using AhmadDAL.Models.Employees;
using AhmadProfileSmarter.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AhmadDAL.DataAccessLayer.Employees
{
    public class EmployeesRepository:IEmployee
    {
        private readonly AppDbContext _context;

        public EmployeesRepository(AppDbContext context)
        {
            _context = context;
        }

        
        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _context.Employee
              .Include(e => e.User)
              .Include(e => e.Participants)
              .ToListAsync();
        }
    }
}
