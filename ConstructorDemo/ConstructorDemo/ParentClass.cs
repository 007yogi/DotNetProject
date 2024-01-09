using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorDemo
{
    public class ParentClass
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string FullName => $"{FirstName} {LastName}";

        public ParentClass(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        } 

        public void Introduce()
        {
            Console.WriteLine($"Hi I'm {FullName}");
        }
    }
}
