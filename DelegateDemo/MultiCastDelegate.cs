using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDemo
{
    public delegate void DelegateTwo(string msg);
    public class MultiCastDelegate
    {
        //public static void Main()
        //{
        //    DelegateTwo del1 = ClassA1.MethodA;
        //    DelegateTwo del2 = ClassB1.MethodB;

        //    DelegateTwo del = del1 + del2;
        //    Console.WriteLine("After del1 + del2");
        //    del("Hello World");
        //    Console.WriteLine("--------");

        //    DelegateTwo del3 = (string msg) => Console.WriteLine("Called lambda expression: " + msg);
        //    del += del3;
        //    Console.WriteLine("After del1 + del2 + del3");
        //    del("Hello World");
        //    Console.WriteLine("--------");

        //    del = del - del2;
        //    Console.WriteLine("After del - del2");
        //    del("Hello World");
        //    Console.WriteLine("--------");

        //    del -= del1;
        //    Console.WriteLine("After del1 - del1");
        //    del("Hello World");

        //    Console.ReadKey();
        //}
    }

    public class ClassA1
    {
        public static void MethodA(string message)
        {
            Console.WriteLine("Called ClassA.MethodA() with parameter: " + message);
        }
    }

    public class ClassB1
    {
        public static void MethodB(string message)
        {
            Console.WriteLine("Called ClassB.MethodB() with parameter: " + message);
        }
    }
}
