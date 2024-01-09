using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class EncapsulationCls
    {
        private string Name;
        private int Age;

        public void setName(string name)    // setter method.
        {
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("name is required.");
            }
            else
            {
                this.Name = name;
            }
        }
        public void getName()       // getter method.
        {
            Console.WriteLine("your name is: " + this.Name);
        }
        public void setAge(int age)
        {
            if (age > 0)
            {
                this.Age = age;
            }
            else
            {
                Console.WriteLine("age should not be zero or negative value.");
            }
        }
        public void getAge()
        {
            if (Age > 0)
            {
                Console.WriteLine("your age is : " + this.Age);
            }
        }
    }
}
