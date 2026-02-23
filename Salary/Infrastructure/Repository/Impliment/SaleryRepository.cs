using Salary.Domain.Entity;
using Salary.Infrastructure.DBContext;
using Salary.Infrastructure.Repository.Interface;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Salary.Infrastructure.Repository.Impliment
{
    public class SaleryRepository : ISaleryRepository
    {
        protected readonly SalaryDbContext _context;

        public SaleryRepository(SalaryDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddAsync(SalaryEntity entity)
        {
            try
            {
                await _context.Set<SalaryEntity>().AddAsync(entity);
                return _context.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(SalaryEntity entity)
        {
            _context.Set<SalaryEntity>().Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<SalaryEntity?> GetById(int id)
        {
            return await _context.Set<SalaryEntity>().FindAsync(id);

        }

        public async Task<bool> UpdateAsync(SalaryEntity entity)
        {
            _context.Set<SalaryEntity>().Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
