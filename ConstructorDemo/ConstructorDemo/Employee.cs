using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorDemo
{
    public class Employee : Person
    {
        public Employee()
        {
            Console.WriteLine("Called Sub Class Parameterless Constructor.");
        }
        public Employee(string name) : base(name)
        {
            Console.WriteLine("Called Sub Class Constructor with Parameter." + name);
        }
    }
}
