using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorDemo
{
    public class CopyConstructor
    {
        private readonly string Name;
        private readonly string Address;

        public CopyConstructor(string name, string address) // Parameterazied constructor
        {
            this.Name = name;
            this.Address = address;
            Console.WriteLine("Parameterazied constructor");
        }
        public CopyConstructor(CopyConstructor e)   // copy constructor
        {
            this.Name = e.Name;
            this.Address = e.Address;
        }

        public void Getdata()
        {
            Console.WriteLine("Person name {0}", Name);
            Console.WriteLine("Person address {0}", Address);
        }
    }
}
