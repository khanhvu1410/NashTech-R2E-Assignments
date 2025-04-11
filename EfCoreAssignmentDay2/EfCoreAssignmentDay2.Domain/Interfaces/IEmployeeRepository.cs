using EfCoreAssignmentDay2.Domain.Entities;

namespace EfCoreAssignmentDay2.Domain.Interfaces
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        public Task<IEnumerable<object>> GetAllWithDepartmentNamesAsync();

        public Task<IEnumerable<object>> GetAllWithProjectsAsync();

        public Task<IEnumerable<object>> GetAllWithSalaryAndJoindedDateAsync();
    }
}
