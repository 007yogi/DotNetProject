using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public delegate int MyDelegate(int x, int y);

namespace DelegateDemo
{
    public class DelegateExp
    {
        private static int Addition(int a, int b)
        {
            return a + b;
        }
        //static void Main(string[] args)
        //{
        //    //int result3 = Addition(5, 6); // call function.
        //    //int result4 = Addition(2, 2); // call function.

        //    MyDelegate del1 = new MyDelegate(Addition);
        //    int result1 = del1(4, 4);
        //    int result2 = del1(2, 2);

        //    Console.WriteLine(result1+ "---" + result2);

        //    Console.ReadKey();
        //}
    }
}
