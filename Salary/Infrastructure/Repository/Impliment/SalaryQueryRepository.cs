using Dapper;
using Microsoft.Data.SqlClient;
using Salary.Application.DTO;
using Salary.Infrastructure.Repository.Interface;
using System.Data;

namespace Salary.Infrastructure.Repository.Impliment
{
    public class SalaryQueryRepository: ISalaryQueryRepository
    {
        private readonly IConfiguration _configuration;

        public SalaryQueryRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private IDbConnection CreateConnection()
            => new SqlConnection(
                _configuration.GetConnectionString("DefaultConnection"));

        //GetById

        public async Task<SalaryReadDto?> Get(int id)
        {
            const string sql = """
        SELECT
            Id,
            FirstName,
            LastName,
            BasicSalary,
            Allowance,
            Transportation,
            OverTime,
            Tax,
            NetSalary,
            Date
        FROM Salaries
        WHERE Id = @Id
    """;

            using var connection = CreateConnection();

            return await connection.QuerySingleOrDefaultAsync<SalaryReadDto>(
                sql,
                new { Id = id });
        }

        //GetRange

        public async Task<IEnumerable<SalaryReadDto>> GetRange(
    string firstName,
    string lastName,
    string fromDate,
    string toDate)
        {
            const string sql = """
        SELECT
            Id,
            FirstName,
            LastName,
            BasicSalary,
            Allowance,
            Transportation,
            OverTime,
            Tax,
            NetSalary,
            Date
        FROM Salaries
        WHERE FirstName = @FirstName
          AND LastName = @LastName
          AND Date BETWEEN @From AND @To
        ORDER BY Date
    """;

            using var connection = CreateConnection();

            return await connection.QueryAsync<SalaryReadDto>(
                sql,
                new
                {
                    FirstName = firstName,
                    LastName = lastName,
                    From = fromDate,
                    To = toDate
                });
        }

    }
}
