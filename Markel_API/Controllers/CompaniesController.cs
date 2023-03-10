using Microsoft.AspNetCore.Mvc;
using Markel_API.Models;
using Markel_API.Interfaces;

namespace Markel_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IInsuranceService _insuranceService;

        public CompaniesController(IInsuranceService insuranceService)
        {
            _insuranceService = insuranceService;
        }

        // GET: api/Companies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> GetAllCompanies()
        {
            var companies = await _insuranceService.GetAllCompanies();
            return Ok(companies);
        }

        // GET: api/Companies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetCompany(int id)
        {
            var company = await _insuranceService.GetCompany(id);

            if (company == null)
            {
                return NotFound();
            }

            return company;
        }

        // GET: api/Companies/5
        [HttpGet("Claims/{companyId}")]
        public async Task<ActionResult<List<Claims>>> GetCompanyClaims(int companyId)
        {
            var claims = await _insuranceService.GetCompanyClaims(companyId);
            if (claims == null || claims.Count == 0)
            {
                return NotFound();
            }
            return Ok(claims);
        }
        
    }
}
