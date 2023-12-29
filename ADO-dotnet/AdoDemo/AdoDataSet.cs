using System.Data;

namespace AdoDemo
{
    public class AdoDataSet
    {
        public static void DataSetDemo()
        {
            try
            {
                DataTable customer = new DataTable("Customer"); // Creating Customer Data Table.

                // Adding Data Columns to the Customer Data Table.
                customer.Columns.Add("ID", typeof (int));
                customer.Columns.Add("Name", typeof (string));
                customer.Columns.Add("Mobile", typeof (string));

                //Adding Data Rows into Customer Data Table.
                customer.Rows.Add("1", "Ankit", "1234567890");
                customer.Rows.Add("2", "Akita", "1234561242");

                // Creating Orders Data Table
                DataTable order = new DataTable("Orders");

                // Adding Data Columns to the Orders Data Table
                order.Columns.Add("ID", typeof (int));
                order.Columns.Add ("CustomerId", typeof (Int32));
                order.Columns.Add("Amount", typeof (int));

                // Adding Data Rows into Orders Data Table
                order.Rows.Add(101, 1, 20000);
                order.Rows.Add(102, 2, 30000);

                //Creating DataSet Object
                DataSet ds = new DataSet();

                //Adding DataTables into DataSet
                ds.Tables.Add(customer);
                ds.Tables.Add(order);

                var countTables = ds.Tables.Count;

                foreach(DataRow row in ds.Tables[0].Rows)
                {
                    Console.WriteLine(row[0] + "/" + row[1]);
                }
            }
            catch(Exception ex) { 
                Console.WriteLine("OOP's", ex.Message);
            }
        }
    }
}
