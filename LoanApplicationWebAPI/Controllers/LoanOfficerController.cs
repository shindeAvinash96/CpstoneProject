using LoanApplicationWebAPI.Models;
using LoanApplicationWebAPI.Services;
using LoanApplicationWebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LoanApplicationWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanOfficersController : ControllerBase
    {
        private readonly ILoanOfficerService _service;

        public LoanOfficersController(ILoanOfficerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAll());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var officer = await _service.GetById(id);
            if (officer == null) return NotFound();
            return Ok(officer);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] LoanOfficer officer)
        {
            var created = await _service.Add(officer);
            return CreatedAtAction(nameof(GetById), new { id = created.UserId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] LoanOfficer officer)
        {
            if (id != officer.UserId) return BadRequest();
            var updated = await _service.Update(officer);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return NoContent();
        }
    }
}
