using EfCoreAssignmentDay2.Application.DTOs;
using EfCoreAssignmentDay2.Application.Interfaces;
using EfCoreAssignmentDay2.Application.Mappings;
using EfCoreAssignmentDay2.Domain.Entities;
using EfCoreAssignmentDay2.Domain.Interfaces;

namespace EfCoreAssignmentDay2.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        private readonly IBaseRepository<Department> _departmentRepository;

        public EmployeeService(IEmployeeRepository employeeRepository, IBaseRepository<Department> departmentRepository)
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
        }

        public async Task<EmployeeDTO> AddEmployeeAsync(EmployeeToAddDTO employeeDto)
        {
            var department = await _departmentRepository.GetByIdAsync(employeeDto.DepartmentId);
            if (department == null)
            {
                throw new KeyNotFoundException($"Department with ID {employeeDto.DepartmentId} wasnot found.");
            }

            Employee employee = employeeDto.ToEmployee();
            await _employeeRepository.AddAsync(employee);
            return employee.ToEmployeeDTO();
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);

            if (employee == null)
            {
                throw new KeyNotFoundException($"Employee with ID {id} was not found.");
            }
            
            await _employeeRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAllEmployeesAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();
            return employees.Select(e => e.ToEmployeeDTO());
        }

        public async Task<EmployeeDTO> GetEmployeeByIdAsync(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);

            if (employee == null)
            {
                throw new KeyNotFoundException($"Employee with ID {id} was not found.");
            }

            return employee.ToEmployeeDTO();
        }

        public async Task<EmployeeDTO> UpdateEmployeeAsync(EmployeeDTO employeeDto)
        {
            var department = await _departmentRepository.GetByIdAsync(employeeDto.DepartmentId);

            if (department == null)
            {
                throw new KeyNotFoundException($"Department with ID {employeeDto.DepartmentId} wasnot found.");
            }

            var employee = await _employeeRepository.GetByIdAsync(employeeDto.Id) ?? throw new KeyNotFoundException($"Department with ID {employeeDto.Id} wasnot found.");
            await _employeeRepository.UpdateAsync(employee);
            return employeeDto;
        }

        public async Task<IEnumerable<object>> GetAllEmployeesWithDepartmentNamesAsync()
        {
            return await _employeeRepository.GetAllWithDepartmentNamesAsync();
        }

        public async Task<IEnumerable<object>> GetAllEmployeesWithProjectsAsync()
        {
            return await _employeeRepository.GetAllWithProjectsAsync();
        }

        public async Task<IEnumerable<object>> GetAllEmployeesWithSalaryAndJoindedDateAsync()
        {
            return await _employeeRepository.GetAllWithSalaryAndJoindedDateAsync();
        }
    }
}
