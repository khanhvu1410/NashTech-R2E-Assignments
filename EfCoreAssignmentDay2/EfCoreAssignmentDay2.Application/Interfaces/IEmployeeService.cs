﻿using EfCoreAssignmentDay2.Application.DTOs;

namespace EfCoreAssignmentDay2.Application.Interfaces
{
    public interface IEmployeeService
    {
        public Task<EmployeeDTO> AddEmployeeAsync(EmployeeToAddDTO employeeDto);

        public Task<IEnumerable<EmployeeDTO>> GetAllEmployeesAsync();

        public Task<EmployeeDTO> GetEmployeeByIdAsync(int id);

        public Task<EmployeeDTO> UpdateEmployeeAsync(EmployeeDTO employeeDto);

        public Task DeleteEmployeeAsync(int id);

        public Task<IEnumerable<EmployeeDepartmentDTO>> GetAllEmployeesWithDepartmentNamesAsync();

        public Task<IEnumerable<EmployeeProjectDTO>> GetAllEmployeesWithProjectsAsync();

        public Task<IEnumerable<EmployeeSalaryDTO>> GetAllEmployeesWithSalaryAndJoindedDateAsync();
    }
}
