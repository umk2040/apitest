using Markel_API.Interfaces;
using Markel_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Markel_API.Services
{
    public class InsuranceService: IInsuranceService
    {
        private readonly ClaimsContext _context;
        public ClaimsContext ClaimsContext => _context;
        public InsuranceService(ClaimsContext context)
        {
            _context = context;
            _context.Database.EnsureCreatedAsync();
        }

        public async Task<IEnumerable<Claims>> GetAllClaims()
        {
            return await _context.Claims.ToListAsync();
        }

        public async Task<Claims> GetClaims(string id)
        {
            var claim = await _context.Claims.FindAsync(id);
            if(claim != null)
                claim.AgeOfTheClaim = (claim.LossDate - claim.ClaimDate).TotalDays;
            return claim;
        }

        public async Task PutClaims(string id, Claims claims)
        {
            if (id != null && claims != null)
                _context.Entry(claims).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Company>> GetAllCompanies()
        {
            return await _context.Companys.Include(x=>x.Claims).ToListAsync();
        }

        public async Task<Company> GetCompany(int id)
        {
            var company = await _context.Companys.Include(x=>x.Claims).Where(x=>x.Id == id).FirstOrDefaultAsync();
            if (company != null)
            {
                if(company.Active && company?.InsuranceEndDate > DateTime.UtcNow)
                    company.HasActiveInsurancePolicy = true;
            }
            return company;
        }

        public async Task<List<Claims>> GetCompanyClaims(int companyId)
        {
            return await _context.Claims.Where(x => x.CompanyId == companyId).ToListAsync();
        }
    }
}
