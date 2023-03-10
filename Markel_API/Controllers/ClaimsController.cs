using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Markel_API.Models;
using Markel_API.Interfaces;

namespace Markel_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimsController : ControllerBase
    {
        private readonly IInsuranceService _insuranceService;

        public ClaimsController(IInsuranceService insuranceService)
        {
            _insuranceService = insuranceService;
        }

        // GET: api/Claims
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Claims>>> GetAllClaims()
        {
            var claims = await _insuranceService.GetAllClaims();
            return Ok(claims);
        }

        // GET: api/Claims/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Claims>> GetClaims(string id)
        {
            var claims = await _insuranceService.GetClaims(id);

            if (claims == null)
            {
                return NotFound();
            }

            return claims;
        }

        // PUT: api/Claims/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClaims(string id, Claims claims)
        {
            if (id != claims.UCR)
            {
                return BadRequest();
            }

            try
            {
                await _insuranceService.PutClaims(id, claims);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClaimsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool ClaimsExists(string id)
        {
            return _insuranceService.ClaimsContext.Claims.Any(e => e.UCR == id);
        }
    }
}
