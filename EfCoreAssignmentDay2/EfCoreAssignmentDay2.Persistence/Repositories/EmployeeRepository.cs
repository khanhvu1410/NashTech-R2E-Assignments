using EfCoreAssignmentDay2.Domain.Entities;
using EfCoreAssignmentDay2.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EfCoreAssignmentDay2.Persistence.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(CompanyDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Employee>> GetAllWithDepartmentsAsync()
        {
            return await _context.Employees
                .Include(e => e.Department)
                .ToListAsync();
        }

        public async Task<IEnumerable<Employee>> GetAllWithProjectsAsync()
        {
            return await _context.Employees
                .Include(e => e.ProjectEmployees)
                    .ThenInclude(pe => pe.Project)
                .ToListAsync();
        }

        public async Task<IEnumerable<Employee>> GetAllWithSalariesAsync()
        {
            return await _context.Employees
                .Include(e => e.Salaries)
                .ToListAsync();
        }
    }
}
