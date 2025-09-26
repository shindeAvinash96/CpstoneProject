using LoanApplicationWebAPI.Models;
using LoanApplicationWebAPI.Services;
using LoanApplicationWebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LoanApplicationWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanSchemesController : ControllerBase
    {
        private readonly ILoanSchemeService _service;

        public LoanSchemesController(ILoanSchemeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAll());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var scheme = await _service.GetById(id);
            if (scheme == null) return NotFound();
            return Ok(scheme);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] LoanScheme scheme)
        {
            var created = await _service.Add(scheme);
            return CreatedAtAction(nameof(GetById), new { id = created.LoanSchemeId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] LoanScheme scheme)
        {
            if (id != scheme.LoanSchemeId) return BadRequest();
            var updated = await _service.Update(scheme);
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
