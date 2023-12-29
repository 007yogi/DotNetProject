using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDemo
{
    public class Program
    {
        public delegate void MyDelegate();
        public void Fun()
        {
            Console.WriteLine("Hiiiiiiiii");
        }

        //static void Main(string[] args)
        //{
        //    Program p1 = new Program();
        //    MyDelegate del1 = new MyDelegate(p1.Fun);
        //    del1();
        //    del1();
        //    del1();

        //    Console.ReadKey();
        //}
    }


}
