using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorDemo
{
    public class ConstructorOverloading
    {
        public ConstructorOverloading()
        {
            Console.WriteLine("Default Constructor");
        }
        public ConstructorOverloading(int a, int b)
        {
            Console.WriteLine("This id second constructor {0}", (a + b));
        }
        public ConstructorOverloading(int a, int b, int c)
        {
            Console.WriteLine("This id third constructor {0}", (a + b + c));
        }
        public ConstructorOverloading(string a, string b)
        {
            Console.WriteLine("This id second constructor {0}", (a + b));
        }
    }
}
