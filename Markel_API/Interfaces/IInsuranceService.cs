using Markel_API.Models;

namespace Markel_API.Interfaces
{
    public interface IInsuranceService
    {
        ClaimsContext ClaimsContext { get; }
        Task<IEnumerable<Claims>> GetAllClaims();
        Task<IEnumerable<Company>> GetAllCompanies();
        Task<Claims> GetClaims(string id);
        Task<Company> GetCompany(int id);
        Task PutClaims(string id, Claims claims);
        Task<List<Claims>> GetCompanyClaims(int companyId);
    }
}
