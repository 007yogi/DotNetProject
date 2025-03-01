using Dapper;
using DapperDemo.DataContext;
using DapperDemo.Interface;
using DapperDemo.Models;

namespace DapperDemo.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly IDapperContext _context;

        public CompanyRepository(IDapperContext context)
        {
            this._context = context;
        }
        public async Task<IEnumerable<Company>> GetCompanies()
        {
            var query = "SELECT Id, Name AS CompanyName, Address, Country FROM Companies";
            using (var conn = _context.CreateConnection())
            {
              var compniesList = await conn.QueryAsync<Company>(query);
              return compniesList.ToList();
            }
        }
    }
}
