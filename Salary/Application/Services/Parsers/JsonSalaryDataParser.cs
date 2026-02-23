using Salary.Application.DTO;
using Salary.Application.Helper;
using Salary.Application.Services.Parsers.Interface;
using Salary.Domain.Models;
using System.Text.Json;

namespace Salary.Application.Services.Parsers
{
    public class JsonSalaryDataParser : ISalaryDataParser
    {
        public SalaryRawDto Parse(string data)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var dto = JsonSerializer.Deserialize<SalaryRawDto>(data, options);

            if (dto == null)
                throw new ArgumentException("Invalid JSON data");

            return dto;
        }
    }
}
