using DapperDemo.Models;

namespace DapperDemo.Interface
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetCompanies();
    }
}
