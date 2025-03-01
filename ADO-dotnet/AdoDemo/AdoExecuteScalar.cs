using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Data.SqlClient;

namespace AdoDemo
{
    public class AdoExecuteScalar
    {        
        public void UseExecuteScalar()
        {
            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["myCon"].ConnectionString;
                //string connStr = "data source=.; database=EmployeeDB; integrated security=SSPI";
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string commandTxt = "select count(id) from AdoDemo";
                    SqlCommand cmd = new SqlCommand(commandTxt, conn);
                    conn.Open();
                    var totalRows = cmd.ExecuteScalar();
                    Console.WriteLine("Total Rows = " + totalRows);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("OOP's, Something went wrong.", ex);
            }
        }        
    }
}
