using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitDemo
{
    public class AsyncClass2
    {
        public static async void Task1()
        {
            Console.WriteLine("Task 1 Starting..." + DateTime.Now);
            await Task.Delay(4000);
            Console.WriteLine("Task 1 Completed!" + DateTime.Now);

        }
        public static async void Task2()
        {
            Console.WriteLine("Task 2 Starting..." + DateTime.Now);
            await Task.Delay(2000);
            Console.WriteLine("Task 2 Completed!" + DateTime.Now);
        }
        public static async void Task3()
        {
            Console.WriteLine("Task 3 Starting..." + DateTime.Now);
            await Task.Delay(5000);
            Console.WriteLine("Task 3 Completed!" + DateTime.Now);
        }
        public static async void Task4()
        {
            Console.WriteLine("Task 4 Starting..." + DateTime.Now);
            await Task.Delay(1000);
            Console.WriteLine("Task 4 Completed!" + DateTime.Now);
        }
        public static void all()
        {
             Task1();
             Task2();
             Task3();
             Task4();
        }
    }
}
