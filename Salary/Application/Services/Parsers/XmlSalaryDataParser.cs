using Salary.Application.DTO;
using Salary.Application.Enum;
using Salary.Application.Helper;
using Salary.Application.Services.Parsers.Interface;
using Salary.Domain.Models;
using System.Globalization;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Salary.Application.Services.Parsers
{
    public class XmlSalaryDataParser : ISalaryDataParser
    {
        public SalaryRawDto Parse(string data)
        {
            var serializer = new XmlSerializer(typeof(SalaryRawDto));

            using var reader = new StringReader(data);
            var dto = serializer.Deserialize(reader) as SalaryRawDto;

            if (dto == null)
                throw new ArgumentException("Invalid XML data");

            return dto;
        }
    }
}
