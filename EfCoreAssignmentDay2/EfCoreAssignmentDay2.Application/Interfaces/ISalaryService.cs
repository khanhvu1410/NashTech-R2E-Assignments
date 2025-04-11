using EfCoreAssignmentDay2.Application.DTOs;

namespace EfCoreAssignmentDay2.Application.Interfaces
{
    public interface ISalaryService
    {
        public Task<SalariesDTO> AddSalariesAsync(SalariesToAddDTO salariesDto);

        public Task<IEnumerable<SalariesDTO>> GetAllSalariesAsync();

        public Task<SalariesDTO> GetSalariesByIdAsync(int id);

        public Task<SalariesDTO> UpdateSalariesAsync(SalariesDTO salariesDto);

        public Task DeleteSalariesAsync(int id);
    }
}
