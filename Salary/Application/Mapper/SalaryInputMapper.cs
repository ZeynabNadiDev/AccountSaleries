using Salary.Application.DTO;
using Salary.Application.Helper;
using Salary.Domain.Models;

namespace Salary.Application.Mapper
{
    public class SalaryInputMapper
    {
        public SalaryInput Map(SalaryRawDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.FirstName))
                throw new ArgumentException("FirstName is required");

            return new SalaryInput
            {
                FirstName = dto.FirstName!,
                LastName = dto.LastName!,
                BasicSalary = dto.BasicSalary,
                Allowance = dto.Allowance,
                Transportation = dto.Transportation,
                Date = PersianDate.ParsePersianDate(dto.Date!)
            };
        }
    }

}
