using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorDemo
{
    public class PrivateConstructor
    {
        public static string Name;

        private PrivateConstructor(string a)    // private consstructor
        {
            
        }
        public static void Getname(string name)
        {
            Name = name;
            Console.WriteLine("Your name is {0}", Name);
        }
    }

}
