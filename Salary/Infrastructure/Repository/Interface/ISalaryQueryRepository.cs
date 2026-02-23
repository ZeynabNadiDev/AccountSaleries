using Salary.Application.DTO;

namespace Salary.Infrastructure.Repository.Interface
{
    public interface ISalaryQueryRepository
    {
        Task<SalaryReadDto?> Get(int id);
        Task<IEnumerable<SalaryReadDto>> GetRange(
            string firstName,
            string lastName,
            string fromDate,
            string toDate);
    }
}
