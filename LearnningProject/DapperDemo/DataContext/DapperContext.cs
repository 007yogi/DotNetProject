using Microsoft.Data.SqlClient;
using System.Data;

namespace DapperDemo.DataContext
{
    public class DapperContext : IDapperContext
    {
        private readonly IConfiguration _config;
        private readonly string _conString;

        public DapperContext(IConfiguration configuration)
        {
            this._config = configuration;
            this._conString = _config.GetConnectionString("DapperCon");
        }
        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_conString);
        }
    }
}
