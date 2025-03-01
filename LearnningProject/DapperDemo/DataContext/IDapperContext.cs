using System.Data;

namespace DapperDemo.DataContext
{
    public interface IDapperContext
    {
        IDbConnection CreateConnection();
    }
}
