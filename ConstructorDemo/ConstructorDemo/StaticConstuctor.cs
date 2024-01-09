using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorDemo
{
    public class StaticConstuctor
    {
        public static string Name;
        public static int Age;
        public string Address; // non-static variable
        static StaticConstuctor()   // static constuctor
        {
            Name = "Yogesh";
            Age = 30;
            Console.WriteLine("Static Constructor invoked!");
        }
        public StaticConstuctor()       // default constuctor
        {
            Name = "Mohit";
            Console.WriteLine("Default Constuctor." + Name);
        }

        public StaticConstuctor(string address)     // Parameterizes constuctor
        {
            Console.WriteLine("Parameterizes constructor {0}", address);
        }
        public void GetDetails()
        {
            Address = "Delhi";
            Console.WriteLine("Person name is {0}", Name);
            Console.WriteLine("Person age is {0}", Age);
            Console.WriteLine("Person age is {0}", Address);
        }
    }
}
