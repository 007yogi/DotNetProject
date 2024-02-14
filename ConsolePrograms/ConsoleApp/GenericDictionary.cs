using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class GenericDictionary
    {
        public static void MyDictionary()
        {
            Dictionary<string, string> mydic = new Dictionary<string, string>();
            mydic.Add("Id", "1001");
            mydic.Add("Name", "Virat");
            mydic.Add("Profile", "Crickter");

            //Console.WriteLine(mydic["Name"]);
            Console.WriteLine(mydic.Count());
            /*foreach (var item in mydic)
            {
                Console.WriteLine("Key is : " + item.Key + " value is: " + item.Value );
            }*/
        }

        public static void MyDictData()
        {
            List<EmployeeData> empdata = new List<EmployeeData>()
            {
                new EmployeeData { Id = 1002, Salary = 20000,Name = "Ramesh", Designation = "Tester"},
                new EmployeeData {Id = 1003, Salary = 30000,Name = "Rajesh", Designation = "Developer"},
                new EmployeeData {Id = 1004, Salary = 10000,Name = "Mahesh", Designation = "Designer"}
            };

            EmployeeData emp1 = new EmployeeData()
            {
                Id = 111,
                Name = "Ramesh",
                Salary = 30000,
                Designation = "Tester"
            };
            EmployeeData emp2 = new EmployeeData()
            {
                Id = 112,
                Name = "Sudesh",
                Salary = 10000,
                Designation = "Developer"
            };
            EmployeeData emp3 = new EmployeeData()
            {
                Id = 113,
                Name = "Rajesh",
                Salary = 20000,
                Designation = "Manager"
            };


            //Dictionary<int, List<EmployeeData>> MyEmp = new Dictionary<int, List<EmployeeData>>();
            Dictionary<int, EmployeeData> MyEmp = new Dictionary<int, EmployeeData>();
            MyEmp.Add(emp1.Id, emp1);
            MyEmp.Add(emp2.Id, emp2);
            MyEmp.Add(emp3.Id, emp3);

            //Console.WriteLine(MyEmp.Count(x=>x.Value.Name.StartsWith("R")));
        }

    }
    class EmployeeData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string Designation { get; set; }
    }
}
