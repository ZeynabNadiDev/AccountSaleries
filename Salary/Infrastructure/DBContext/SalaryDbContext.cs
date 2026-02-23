using Microsoft.EntityFrameworkCore;
using Salary.Domain.Entity;

namespace Salary.Infrastructure.DBContext
{
    public class SalaryDbContext:DbContext
    {
        public SalaryDbContext(DbContextOptions<SalaryDbContext> options)
        : base(options)
        {
        }

        public DbSet<SalaryEntity> Salaries => Set<SalaryEntity>();
    }
}
