using Salary.Application.DTO;
using Salary.Domain.Models;

namespace Salary.Application.Services.Salery
{
    public interface ISalaryCalculatorService
    {
        SalaryResult Calculate(SalaryInput input, string overTimeCalculator);
    }
}
