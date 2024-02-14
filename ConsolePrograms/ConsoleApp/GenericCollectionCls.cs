using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio.Rest.Studio.V2.Flow;

namespace ConsoleApp
{
    public class GenericCollectionCls
    {
        public static void StandardList()
        {
            List<int> list = new List<int>();
            list.Add(10);
            list.Add(20);
            list.Add(30);
            list.Add(20);
            //list.Insert(1, 50);
            //Console.WriteLine(list.IndexOf(20));

            foreach (object i in list)
            {
                Console.WriteLine(i);
            }
            //Console.WriteLine(list[2]);
        }

        public static void GenericListFunc()
        {
            /*List<Employee> emplist = new List<Employee>()
            {
                new Employee{Id = 1, Name = "Amit",age = 30,Designation = "Manager"},
                new Employee{Id = 1,Name = "Smit",age = 25,Designation = "Developer"},
                new Employee{Id = 1,Name = "Rahul",age = 35,Designation = "Tester"},
            };*/
            Employee emp1 = new Employee()
            {
                Id = 1,
                Name = "Amit",
                age = 30,
                Designation = "Manager"
            };
            Employee emp2 = new Employee()
            {
                Id = 1,
                Name = "Smit",
                age = 35,
                Designation = "Developer"
            };
            Employee emp3 = new Employee()
            {
                Id = 1,
                Name = "Rahul",
                age = 35,
                Designation = "Tester"
            };
            List<Employee> emplist = new List<Employee>();
            emplist.Add(emp1);
            emplist.Add(emp2);
            emplist.Add(emp3);
            
            Employee[] empArr = emplist.ToArray();
            List<Employee> empls = empArr.ToList<Employee>();

            //List<Employee> ee = emplist.FindAll(x => x.age > 30);
            //Console.WriteLine("Emp name is {0} age is {1}", ee.Name, ee.age);

            //Console.WriteLine(emplist.Exists(x => x.Name.StartsWith("z")));
            //emplist.Reverse();

            foreach (Employee item in emplist)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int age { get; set; }
        public string Designation { get; set; }
    }
}
