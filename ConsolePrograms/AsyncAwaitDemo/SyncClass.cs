using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitDemo
{
    public class SyncClass
    {
        public static void Task1()
        {
            Console.WriteLine("Task 1 Starting..." + DateTime.Now);
            //Thread.Sleep(4000);
            Console.WriteLine("Task 1 Completed!" + DateTime.Now);

        }
        public static void Task2()
        {
            Console.WriteLine("Task 2 Starting..." + DateTime.Now);
            //Thread.Sleep(2000);
            Console.WriteLine("Task 2 Completed!" + DateTime.Now);
        }
        public static void Task3()
        {
            Console.WriteLine("Task 3 Starting..." + DateTime.Now);
            Thread.Sleep(5000);
            Console.WriteLine("Task 3 Completed!" + DateTime.Now);
        }
        public static void Task4()
        {
            Console.WriteLine("Task 4 Starting..." + DateTime.Now);
            //Thread.Sleep(1000);
            Console.WriteLine("Task 4 Completed!" + DateTime.Now);
        }
        public static void AllTasks()
        {
            Task.Run(() =>
            {
                Task1();
            });
            Task.Run(() =>
            {
                Task2();
            });
            Task.Run(() =>
            {
                Task3();
            });
            Task.Run(() =>
            {
                Task4();
            });
        }
    }
}
