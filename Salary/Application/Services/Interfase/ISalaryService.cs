using Salary.Application.DTO;
using Salary.Application.Enum;

namespace Salary.Application.Services.Interfase
{
    public interface ISalaryService
    {
        Task<SalaryResult> AddSalaryUser(SalaryInputType dataType, SalaryRequest request);
        Task<bool> UpdateSalaryUser(SalaryInputType dataType, int id, SalaryRequest request);
        public Task<bool> DeleteSalaryUser(int id);

        Task<SalaryReadDto?> Get(int id);

        Task<IEnumerable<SalaryReadDto>> GetRange(
            string firstName,
            string lastName,
            string fromDate,
            string toDate);
    }
}
