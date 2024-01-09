using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorDemo
{
    public class Person
    {
        public Person()
        {
            Console.WriteLine("Called Base Class Parameterless Constructor.");
        }
        public Person(string name)
        {
            Console.WriteLine("Called Base Class Constructor with parameter." + name);
        }
    }
}
