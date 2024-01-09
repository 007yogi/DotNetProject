using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorDemo
{
    public class DestructorCls
    {
        public string Name;
        public int Age;
        public DestructorCls(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string GetName()
        {
            return this.Name;
        }
        public int GetAge()
        {
            return this.Age;
        }
        ~DestructorCls()
        {
            Console.WriteLine("Destructor invoked!");
        }
    }
}
