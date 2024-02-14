using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericConsoleDemo
{
    public class GenericMethods
    {
        public static void ShowArray<T>(T[] arr)
        {
            foreach (T i in arr)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("-------------------");
        }

        public static bool CheckValue<T>(T a, T b)
        {
            bool c = a.Equals(b);
            return c;
        }
        public static bool CheckValue2(object a, string b, int d = 10)
        {
            bool x = a.Equals(b);
            return x;
        }
    }
}
