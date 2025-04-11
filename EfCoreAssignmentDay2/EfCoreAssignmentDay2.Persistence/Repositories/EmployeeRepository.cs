using EfCoreAssignmentDay2.Domain.Entities;
using EfCoreAssignmentDay2.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EfCoreAssignmentDay2.Persistence.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly CompanyDbContext _context;

        public EmployeeRepository(CompanyDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task DeleteAsync(int id)
        {
            var employee = await GetByIdAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<object>> GetAllEmployeesAndDepartmentNamesAsync()
        {
            return await _context.Employees.Include(e => e.Department).Select(e => new
            {
                e.Id, 
                e.Name,
                e.JoinedDate,
                DepartmentName = e.Department!.Name
            }).ToListAsync();
        }

        public async Task<IEnumerable<object>> GetAllEmployeesAndProjectsAsync()
        {
            return await _context.Employees.Include(e => e.ProjectEmployees).Select(e => new
            {
                e.Id,
                e.Name,
                e.JoinedDate,
                Projects = e.ProjectEmployees
            }).ToListAsync();
        }

        public async Task<IEnumerable<object>> GetAllEmployeesWithSalaryAndJoindedDateAsync()
        {
            return await _context.Employees.Include(e => e.Salary)
                .Where(e => e.Salary!.Salary > 100 && e.JoinedDate >= new DateTime(2024, 1, 1))
                .Select(e => new
            {
                e.Id, 
                e.Name,
                e.JoinedDate,
                e.Salary!.Salary
            }).ToListAsync();
        }
    }
}
