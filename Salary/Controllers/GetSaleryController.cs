using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Salary.Application.Services.Interfase;

namespace Salary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetSaleryController : ControllerBase
    {
        private readonly ISalaryService _salaryService;

        public GetSaleryController(ISalaryService salaryService)
        {
            _salaryService = salaryService;
        }
        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _salaryService.Get(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("getrange")]
        public async Task<IActionResult> GetRange(
            string firstName,
            string lastName,
            string from,
            string to)
        {
            var result = await _salaryService.GetRange(
                firstName, lastName, from, to);

            return Ok(result);
        }
    }
}
