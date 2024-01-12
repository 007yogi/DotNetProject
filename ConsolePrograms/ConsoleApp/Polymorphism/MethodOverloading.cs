using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Polymorphism
{
    public class MethodOverloading
    {
        public void Add()
        {
            int a = 10;
            int b = 20;
            int c = a + b;
            Console.WriteLine(c);
        }
        public void Add(int a, int b)
        {
            int c = a + b;
            Console.WriteLine(c);
        }
        public void Add(float a, float b)
        {
            float c = a + b;
            Console.WriteLine(c);
        }
        public void Add(string str1, string str2, string str3)
        {
            string str = $"my name is {str1} / {str2} / {str3}";
            Console.WriteLine(str);
        }
    }
}
