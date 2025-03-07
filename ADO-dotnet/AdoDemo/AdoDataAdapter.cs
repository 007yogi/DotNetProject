﻿using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AdoDemo
{
    public class AdoDataAdapter
    {
        // Not suport "IConfiguration" in .netframework it work with .NetCore
        private readonly IConfiguration _config;

        public AdoDataAdapter(IConfiguration config)
        {
            _config = config;
        }
        public void DataAdapterWithDataSet()
        {
            try
            {
                // use "ConfigurationManager" in .netframework.
                string conStr = ConfigurationManager.ConnectionStrings["myCon"].ConnectionString;
                //string conStr = _config.GetConnectionString("myCon");

                using (SqlConnection con = new SqlConnection(conStr))
                {
                    //string commandText = "select * from AdoDemo; select * from products; select * from Student";
                    //SqlCommand cmd = new SqlCommand(commandText, con);
                    //cmd.CommandType = CommandType.Text;
                    //SqlDataAdapter da = new SqlDataAdapter(cmd);

                    SqlDataAdapter da = new SqlDataAdapter("select * from AdoDemo; select * from products; select * from Student", con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    var tbl = ds.Tables.Count;

                    for (var i = 0; i < tbl; i++)
                    {
                        foreach (DataRow row in ds.Tables[i].Rows)
                        {
                            Console.WriteLine(row[0] + " " + row[1]);
                        }
                        Console.WriteLine("----------------------------");
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("OOPs, something went wrong." + ex);
            }
            Console.ReadKey();
        }

        public void DataAdapterWithDataTable()
        {
            try
            {
                string conStr = ConfigurationManager.ConnectionStrings["myCon"].ConnectionString;
                //string conStr = "data source=.;database=EmployeeDB;integrated security=SSPI";
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    string commandText = "select * from AdoDemo ";
                    SqlCommand cmd = new SqlCommand(commandText, con);

                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        Console.WriteLine(row[0] + " " + row[1]);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.ReadKey();

        }

        public void DataAdapterExecuteStoredProcedure()
        {
            try
            {
                //string conStr = "data source=.; database=EmployeeDB; integrated security=SSPI";
                string conStr = ConfigurationManager.ConnectionStrings["myCon"].ConnectionString;
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    //SqlCommand cmd = new SqlCommand();
                    //cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter("spGetAdoDemo", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        Console.WriteLine(row[1]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("OOP's", ex);
            }
            Console.ReadKey();
        }
    }
}
