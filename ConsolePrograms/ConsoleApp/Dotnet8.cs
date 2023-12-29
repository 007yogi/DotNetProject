using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Dotnet8
    {
        public class Person2
        {
            public const int a = 10;
            public string Name;
            public int Age;
            public Person2(string name, int age)
            {
                Name = name;
                Age = age;
            }
        }

        public class Person(string name, int age)
        {
            public string Name { get; } = name; // initialize a readonly property
            public int Age { get; set; } = age; // initialize a read-write property
        }
        public class Student(string name, int age, string school) : Person(name, age)
        {
            public string School { get; } = school;
        }
    }
}
