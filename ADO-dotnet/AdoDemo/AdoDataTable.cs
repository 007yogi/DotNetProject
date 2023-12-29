using System.Data;

namespace AdoDemo
{
    public class AdoDataTable
    {
        public void CreateDataTableFun()
        {
            try
            {
                // Create Data Table
                DataTable dt = new DataTable("Student");
                // Add Data Columns 
                DataColumn Id = new DataColumn("ID");
                Id.DataType = typeof(int);
                Id.Unique = true;
                Id.AllowDBNull = false;
                Id.Caption = "Student Id";
                dt.Columns.Add(Id);

                DataColumn Name = new DataColumn("Name");
                Name.MaxLength = 20;
                Name.AllowDBNull=false;
                dt.Columns.Add(Name);

                DataColumn Email = new DataColumn("Email");
                dt.Columns.Add(Email);

                // setting the primary key
                dt.PrimaryKey = new DataColumn[] { Id};

                DataRow row1 = dt.NewRow();
                row1["Id"] = 101;
                row1["Name"] = "Yogesh";
                row1["Email"] = "yogesh001@gmail.com";
                dt.Rows.Add(row1);
                dt.Rows.Add(102, "Alexa", "alexa007@gmail.com");

                foreach (DataRow row in dt.Rows)
                {
                    Console.WriteLine(row[0] + ", " + row[1] + ", " + row[2]);
                }
            }
            catch(Exception ex) { 
                Console.WriteLine(ex.Message);
            }
        }
    }
}
