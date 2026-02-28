using AhmadDAL.Data;
using AhmadDAL.Models.Employees;
using Microsoft.EntityFrameworkCore;

namespace AhmadDAL.DataAccessLayer.Employees
{
    public class EmployeesRepository
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
