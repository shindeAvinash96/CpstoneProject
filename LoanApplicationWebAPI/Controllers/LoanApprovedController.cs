using LoanApplicationWebAPI.Models;
using LoanApplicationWebAPI.Services;
using LoanApplicationWebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LoanApplicationWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanApprovedController : ControllerBase
    {
        private readonly ILoanApprovedService _service;

        public LoanApprovedController(ILoanApprovedService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAll());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var approved = await _service.GetById(id);
            if (approved == null) return NotFound();
            return Ok(approved);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] LoanApproved approved)
        {
            var created = await _service.Add(approved);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] LoanApproved approved)
        {
            if (id != approved.Id) return BadRequest();
            var updated = await _service.Update(approved);
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
