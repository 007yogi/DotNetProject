using IronXL;
using System.Data;
using System.Data.SqlClient;

namespace GenerateExcelDemo
{
    public class ExcelDemoRepo : BaseConnection, IExcelDemo
    {
        private string logFilesDir = string.Empty;
        public ExcelDemoRepo(IConfiguration config) : base(config)
        {
            var currentdir = Directory.GetCurrentDirectory();
            logFilesDir = currentdir + "\\ExcelFiles";
            if (!Directory.Exists(logFilesDir))
            {
                Directory.CreateDirectory(logFilesDir);
            }
        }
        public void GenerateExcelFile()
        {
            DateTime IndianTime = DateTime.UtcNow.AddHours(5.5);
            string fileName = logFilesDir + "\\" + "budget" + IndianTime.ToString("ddMMMyyyy") + ".xlsx";

            WorkBook workbook = WorkBook.Create(ExcelFileFormat.XLSX);
            var sheet = workbook.CreateWorkSheet("Result Sheet");

            // Set Cell Values Manually
            sheet["A1"].Value = "Col1";
            sheet["B1"].Value = "Col2";
            sheet["C1"].Value = "Col3";
            sheet["D1"].Value = "Col4";

            Random r = new Random();
            for (int i = 1; i <= 4; i++)
            {
                sheet["A" + i].Value = r.Next(1, 100);
                sheet["B" + i].Value = r.Next(1, 100);
                sheet["C" + i].Value = r.Next(1, 100);
                sheet["D" + i].Value = r.Next(1, 100);
            }
            // Save Workbook
            workbook.SaveAs(fileName);
        }

        public void ExportDynamicallyData()
        {
            DateTime IndianTime = DateTime.UtcNow.AddHours(5.5);
            string fileName = logFilesDir + "\\" + "result" + IndianTime.ToString("ddMMMyyyy") + ".xlsx";

            WorkBook workbook = WorkBook.Create(ExcelFileFormat.XLSX);
            var sheet = workbook.CreateWorkSheet("Result Sheet");

            using (var conn = new SqlConnection(_connString))
            {
                string sql = "select * from [dbo].[Employee]";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                conn.Open();
                da.Fill(ds);
                //Loop through Column
                var arr ="A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z".Split(",");
                foreach (DataTable table in ds.Tables)
                {
                    for (int i = 0; i < table.Columns.Count; i++)
                    {
                        sheet[arr[i]+"1"].Value = table.Columns[i].ColumnName.ToString();
                    }
                }
                //Loop through contents of dataset
                foreach (DataTable table1 in ds.Tables)
                {
                    for (int j = 0; j < table1.Rows.Count; j++)
                    {
                        for (int i = 0; i < table1.Columns.Count; i++)
                        {
                            sheet[arr[i] + (j + 2)].Value = table1.Rows[j][i].ToString();
                        }
                    }
                }
                // Save Workbook
                workbook.SaveAs(fileName);
            }
        }
    }
}
