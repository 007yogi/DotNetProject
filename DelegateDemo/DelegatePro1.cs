using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDemo
{
    public delegate void DelegateOne(string msg);
    public class DelegatePro1
    {
        public static void Main()
        {
            // set target method.
            var ss = ClassA.subs(6, 5);
            Console.WriteLine(ss);

            DelegateOne del1 = new DelegateOne(ClassA.MethodA);
            del1("Hello World");

            DelegateOne del = ClassB.MethodB;
            del("Hello World");

            // set lambda expression.
            del = (string msg) => Console.WriteLine("Called lambda expression: " + msg);
            del("Hello World");

            Console.ReadKey();            
        }
    }

    // function signature must match with delegate signature.
    public class ClassA
    {
        // target method.
        public static void MethodA(string message)
        {
            Console.WriteLine("Called ClassA.MethodA() with parameter: " + message);
        }
        public static int subs(int a, int b)
        {
            return (a - b);
        }
    }

    public class ClassB
    {
        public static void MethodB(string message)
        {
            Console.WriteLine("Called ClassB.MethodB() with parameter: " + message);
        }
    }
}
