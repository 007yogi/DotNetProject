using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDemo
{
    public class AdoExecuteReader
    {
        public bool UseExecuteReader()
        {
            bool result = false;
            try
            {
                //string conStr = "data source=.; database=EmployeeDB; integrated security=true";
                string conStr = ConfigurationManager.ConnectionStrings["myCon"].ConnectionString;
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    string commandText = "select * from AdoDemo; select * from products";
                    SqlCommand cmd = new SqlCommand(commandText, con);
                    con.Open();

                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        Console.WriteLine(sdr[0] + " " + sdr[1]);
                    }
                    while (sdr.NextResult())
                    {
                        while (sdr.Read())
                        {
                            Console.WriteLine(sdr[0] + " " + sdr[1]);
                        }
                    }
                }
                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("error", ex);
            }
            return result;
        }
    }
}
