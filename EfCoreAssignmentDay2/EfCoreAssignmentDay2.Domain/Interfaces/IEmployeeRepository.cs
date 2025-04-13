using EfCoreAssignmentDay2.Domain.Entities;

namespace EfCoreAssignmentDay2.Domain.Interfaces
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        public Task<IEnumerable<Employee>> GetAllWithDepartmentsAsync();

        public Task<IEnumerable<Employee>> GetAllWithProjectsAsync();

        public Task<IEnumerable<Employee>> GetAllWithSalariesAsync();
    }
}
