using EfCoreAssignmentDay2.Application.DTOs;
using EfCoreAssignmentDay2.Application.Interfaces;
using EfCoreAssignmentDay2.Application.Mappings;
using EfCoreAssignmentDay2.Domain.Entities;
using EfCoreAssignmentDay2.Domain.Interfaces;

namespace EfCoreAssignmentDay2.Application.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IBaseRepository<Department> _departmentRepository;

        public DepartmentService(IBaseRepository<Department> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<DepartmentDTO> AddDepartmentAsync(DepartmentToAddDTO departmentDto)
        {
            Department department = departmentDto.ToDepartment();
            await _departmentRepository.AddAsync(department);
            return department.ToDepartmentDTO();
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            var department = await _departmentRepository.GetByIdAsync(id); 
            
            if (department == null)
            {
                throw new KeyNotFoundException($"Department with ID {id} was not found.");
            }
            
            await _departmentRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<DepartmentDTO>> GetAllDepartmentsAsync()
        {
            var departments = await _departmentRepository.GetAllAsync();
            return departments.Select(d => d.ToDepartmentDTO());
        }

        public async Task<DepartmentDTO> GetDepartmentByIdAsync(int id)
        {
            var department = await _departmentRepository.GetByIdAsync(id);

            if (department == null)
            {
                throw new KeyNotFoundException($"Department with ID {id} was not found.");
            }

            return department.ToDepartmentDTO(); 
        }

        public async Task<DepartmentDTO> UpdateDepartmentAsync(DepartmentDTO departmentDto)
        {
            var department = await _departmentRepository.GetByIdAsync(departmentDto.Id) ?? throw new KeyNotFoundException($"Department with ID {departmentDto.Id} was not found.");
            await _departmentRepository.UpdateAsync(department);
            return departmentDto;
        }
    }
}
