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

        public async Task<IEnumerable<object>> GetAllWithDepartmentNamesAsync()
        {
            return await _context.Employees.Include(e => e.Department).Select(e => new
            {
                e.Id, 
                e.Name,
                e.JoinedDate,
                DepartmentName = e.Department!.Name
            }).ToListAsync();
        }

        public async Task<IEnumerable<object>> GetAllWithProjectsAsync()
        {
            return await _context.Employees.Include(e => e.ProjectEmployees).Select(e => new
            {
                e.Id,
                e.Name,
                e.JoinedDate,
                Projects = e.ProjectEmployees
            }).ToListAsync();
        }

        public async Task<IEnumerable<object>> GetAllWithSalaryAndJoindedDateAsync()
        {
            return await _context.Employees.Include(e => e.Salaries)
                .Where(e => e.Salaries!.Salary > 100 && e.JoinedDate >= new DateTime(2024, 1, 1))
                .Select(e => new
            {
                e.Id, 
                e.Name,
                e.JoinedDate,
                e.Salaries!.Salary
            }).ToListAsync();
        }
    }
}
