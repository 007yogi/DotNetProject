using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorDemo
{
    public class ConstructorChaining
    {
        public ConstructorChaining() : this(10)
        {
            Console.WriteLine("Constructor 1: no parameter constructor method, calls the second constructor");
        }
        public ConstructorChaining(int age)
        {
            Console.WriteLine("Constructor 2: constructor with one parameter");
        }
    }
}
