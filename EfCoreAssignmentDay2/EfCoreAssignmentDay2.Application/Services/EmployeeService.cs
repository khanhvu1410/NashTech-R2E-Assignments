﻿using EfCoreAssignmentDay2.Application.DTOs;
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

        public async Task<IEnumerable<EmployeeDepartmentDTO>> GetAllEmployeesWithDepartmentNamesAsync()
        {
            var employees = await _employeeRepository.GetAllWithDepartmentsAsync();
            return employees
                .Select(e => new EmployeeDepartmentDTO
            { 
                Id = e.Id,
                Name = e.Name,
                JoinedDate = e.JoinedDate,
                DepartmentName = e.Department?.Name
            });
        }

        public async Task<IEnumerable<EmployeeProjectDTO>> GetAllEmployeesWithProjectsAsync()
        {
            var employees = await _employeeRepository.GetAllWithProjectsAsync();
            return employees
                .Select(e => new EmployeeProjectDTO
            {
                Id = e.Id,
                Name = e.Name,
                JoinedDate = e.JoinedDate,
                ProjectNames = e.ProjectEmployees?
                    .Select(pe => pe.Project!.Name)
                    .ToList()
            });
        }

        public async Task<IEnumerable<EmployeeSalaryDTO>> GetAllEmployeesWithSalaryAndJoindedDateAsync()
        {
            var employees = await _employeeRepository.GetAllWithSalariesAsync();
            return employees
                .Where(e => e.Salaries != null)
                .Where(e => e.Salaries!.Salary > 100 && e.JoinedDate >= new DateTime(2024, 1, 1))
                .Select(e => new EmployeeSalaryDTO
            {
                Id = e.Id,
                Name = e.Name,
                JoinedDate = e.JoinedDate,
                Salary = e.Salaries!.Salary
            });
        }
    }
}
