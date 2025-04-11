using EfCoreAssignmentDay2.Domain.Entities;

namespace EfCoreAssignmentDay2.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllAsync();

        Task<Employee?> GetByIdAsync(int id);

        Task AddAsync(Employee entity);

        Task UpdateAsync(Employee entity);

        Task DeleteAsync(int id);

        public Task<IEnumerable<object>> GetAllEmployeesAndDepartmentNamesAsync();

        public Task<IEnumerable<object>> GetAllEmployeesAndProjectsAsync();

        public Task<IEnumerable<object>> GetAllEmployeesWithSalaryAndJoindedDateAsync();
    }
}
