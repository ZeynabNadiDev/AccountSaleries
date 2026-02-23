using Salary.Application.DTO;
using Salary.Domain.Models;

namespace Salary.Application.Services.Parsers.Interface
{
    public interface ISalaryDataParser
    {
      public SalaryRawDto Parse(string data); 
    }
}
