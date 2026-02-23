
using Microsoft.EntityFrameworkCore;
using OvertimePolicies;
using Salary.Application.Mapper;
using Salary.Application.Services;
using Salary.Application.Services.Interfase;
using Salary.Application.Services.Parsers;
using Salary.Application.Services.Parsers.Interface;
using Salary.Application.Services.Salery;
using Salary.Infrastructure.DBContext;
using Salary.Infrastructure.Repository.Impliment;
using Salary.Infrastructure.Repository.Interface;
using Salary.WebApi.Services;

namespace Salary
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<SalaryDbContext>(options =>
            {
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            //DI
            builder.Services.AddScoped<ISaleryRepository, SaleryRepository>();
            builder.Services.AddScoped<ISalaryQueryRepository, SalaryQueryRepository>();
            builder.Services.AddScoped<ISalaryService, SalaryService>();
            builder.Services.AddScoped<ISalaryCalculatorService, SalaryCalculatorService>();

            builder.Services.AddScoped<SalaryInputMapper>();

            builder.Services.AddScoped<CustomSalaryDataParser>();
            builder.Services.AddScoped<JsonSalaryDataParser>();
            builder.Services.AddScoped<XmlSalaryDataParser>();

            builder.Services.AddScoped<ISalaryDatatypeFactory, SalaryDataTypeFactory>();

            builder.Services.AddScoped<OvertimeCalculator>();
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            //    app.UseSwagger();
            //    app.UseSwaggerUI();
            //}
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
