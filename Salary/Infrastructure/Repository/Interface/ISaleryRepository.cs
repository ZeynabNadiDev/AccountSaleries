using Salary.Domain.Entity;

namespace Salary.Infrastructure.Repository.Interface
{
    public interface ISaleryRepository
    {
      Task  <SalaryEntity> GetById(int id);
        Task <bool> AddAsync(SalaryEntity entity);
        Task<bool> UpdateAsync(SalaryEntity entity);

        Task<bool> Delete(SalaryEntity entity);
    }
}
