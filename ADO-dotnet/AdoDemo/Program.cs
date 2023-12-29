using System.Data.SqlClient;

namespace AdoDemo
{
    public class Program 
    {     
        public static void Main(string[] args)
        {
            //new Program().CreateInsertDeleteUpdateCommand();
            //new Program().SelectAllRecord();

            //new AdoExecuteScalar().UseExecuteScalar();
            new AdoExecuteReader().UseExecuteReader();

            //new AdoDataAdapter().DataAdapterWithDataSet();
            //new AdoDataAdapter().DataAdapterWithDataTable();
            //new AdoDataAdapter().DataAdapterExecuteStoredProcedure();

            //new AdoDataTable().CreateDataTableFun();

            //new AdoDataSet().DataSetDemo();

            Console.ReadKey();
        }

        public void CreateInsertDeleteUpdateCommand()
        {
            string connString = "data source=.; database=EmployeeDB; integrated security=SSPI";
            SqlConnection conn = null;
            bool isValid = false;
            try
            {
                conn = new SqlConnection(connString);
                //string command = "create table AdoDemo(id int not null, name varchar(50), email varchar(50))";
                string command = "insert into AdoDemo (name, email) values ('Maneesha', 'maneesha123@gmail.com')";
                //string command = " delete from AdoDemo where id='1' ";
                //string command = "update AdoDemo set name = 'Anita', email = 'anita221@gmail.com' where id = 3";

                SqlCommand cmd = new SqlCommand(command, conn);

                conn.Open();
                isValid = true;

                int rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine("command executed succesfully.");               
                conn.Close();
            }
            catch (Exception ex)
            {
                isValid = false;
                Console.WriteLine("OOPs, something went wrong." + ex);
            }
        }

        public void SelectAllRecord()
        {
            SqlConnection conn = null;
            bool isValid = false;
            string connString = "data source=.; database=EmployeeDB; integrated security=SSPI";
            try
            {
                conn = new SqlConnection(connString);
                string command = "select * from AdoDemo";
                SqlCommand cmd = new SqlCommand(command, conn);

                conn.Open();
                isValid = true;

                SqlDataReader sdr = cmd.ExecuteReader();
                
                while (sdr.Read())
                {
                    Console.WriteLine(sdr["id"] + " " + sdr["name"]);
                }

                Console.WriteLine("display data succesfully.");
                conn.Close();
            }
            catch (Exception ex)
            {
                isValid = false;
                Console.WriteLine("OOPs, something went wrong." + ex);
            }
        }

        
    }
}