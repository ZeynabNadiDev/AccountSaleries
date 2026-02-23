using Salary.Application.DTO;
using Salary.Application.Helper;
using Salary.Application.Services.Parsers.Interface;
using Salary.Domain.Models;

namespace Salary.Application.Services.Parsers
{
    public class CustomSalaryDataParser : ISalaryDataParser
    {
        public SalaryRawDto Parse(string data)
        {
            var lines = data.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            if (lines.Length < 2)
                throw new ArgumentException("Invalid custom format");

            var headers = lines[0].Split('/');
            var values = lines[1].Split('/');

            var dto = new SalaryRawDto();

            for (int i = 0; i < headers.Length; i++)
            {
                var key = headers[i].Trim().ToLowerInvariant();
                var value = values[i].Trim();

                switch (key)
                {
                    case "firstname": dto.FirstName = value; break;
                    case "lastname": dto.LastName = value; break;
                    case "basicsalary": dto.BasicSalary = decimal.Parse(value); break;
                    case "allowance": dto.Allowance = decimal.Parse(value); break;
                    case "transportation": dto.Transportation = decimal.Parse(value); break;
                    case "date": dto.Date = value; break;
                }
            }

            return dto;
        }
    }

}
