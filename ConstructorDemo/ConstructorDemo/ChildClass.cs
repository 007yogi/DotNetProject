using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorDemo
{
    public class ChildClass : ParentClass
    {
        public string JobTitle { get; set; }
        public int Salary { get; set; }
        public ChildClass(string firstname, string lastname, int age, string jobTitle, int salary):base(firstname, lastname, age)
        {
            JobTitle = jobTitle;
            Salary = salary;
        }       
        public void Profile()
        {
            Console.WriteLine($"My Profile is {JobTitle} & {Salary}");
        }
    }
}
