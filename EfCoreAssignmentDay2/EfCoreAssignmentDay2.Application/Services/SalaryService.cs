using EfCoreAssignmentDay2.Application.DTOs;
using EfCoreAssignmentDay2.Application.Interfaces;
using EfCoreAssignmentDay2.Application.Mappings;
using EfCoreAssignmentDay2.Domain.Entities;
using EfCoreAssignmentDay2.Domain.Interfaces;

namespace EfCoreAssignmentDay2.Application.Services
{
    public class SalaryService : ISalaryService
    {
        private readonly IBaseRepository<Salaries> _salaryRepository;

        private readonly IEmployeeRepository _employeeRepository;

        public SalaryService(IBaseRepository<Salaries> salaryRepository, IEmployeeRepository employeeRepository)
        {
            _salaryRepository = salaryRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task<SalariesDTO> AddSalariesAsync(SalariesToAddDTO salariesDto)
        {
            var employee = await _employeeRepository.GetByIdAsync(salariesDto.EmployeeId);
            if (employee == null)
            {
                throw new KeyNotFoundException($"Employee with ID {salariesDto.EmployeeId} was not found.");
            }

            Salaries salaries = salariesDto.ToSalaries();
            await _salaryRepository.AddAsync(salaries);
            return salaries.ToSalariesDTO();
        }

        public async Task DeleteSalariesAsync(int id)
        {
            var salaries = await _salaryRepository.GetByIdAsync(id);

            if (salaries == null)
            {
                throw new KeyNotFoundException($"Salaries with ID {id} was not found.");
            }

            await _salaryRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<SalariesDTO>> GetAllSalariesAsync()
        {
            var salaries = await _salaryRepository.GetAllAsync();
            return salaries.Select(s => s.ToSalariesDTO());
        }

        public async Task<SalariesDTO> GetSalariesByIdAsync(int id)
        {
            var salaries = await _salaryRepository.GetByIdAsync(id);

            if (salaries == null)
            {
                throw new KeyNotFoundException($"Salaries with ID {id} was not found.");
            }

            return salaries.ToSalariesDTO();
        }

        public async Task<SalariesDTO> UpdateSalariesAsync(SalariesDTO salariesDto)
        {
            var employee = await _employeeRepository.GetByIdAsync(salariesDto.EmployeeId);
            if (employee == null)
            {
                throw new KeyNotFoundException($"Employee with ID {salariesDto.EmployeeId} was not found.");
            }

            var salaries = await _salaryRepository.GetByIdAsync(salariesDto.Id) ?? throw new KeyNotFoundException($"Salaries with ID {salariesDto.Id} wasnot found.");
            await _salaryRepository.UpdateAsync(salaries);
            return salariesDto;
        }
    }
}
