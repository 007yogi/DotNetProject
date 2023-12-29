using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitDemo
{
    public class AsyncClass
    {
        public static async Task AsyncTask1()
        {
            Task mytask = Task.Run(() =>
            {
                Console.WriteLine("Async Task 1 Starting..." + DateTime.Now);
                Thread.Sleep(4000);
                Console.WriteLine("Async Task 1 Completed!" + DateTime.Now);
            });
            await mytask;
        }
        public static async Task AsyncTask2()
        {
            Task mytask = Task.Run(() =>
            {
                Console.WriteLine("Async Task 2 Starting..." + DateTime.Now);
                Thread.Sleep(2000);
                Console.WriteLine("Async Task 2 Completed!" + DateTime.Now);
            });
            await mytask;
        }
        public static async Task AsyncTask3()
        {
            Task mytask = Task.Run(() =>
            {
                Console.WriteLine("Async Task 3 Starting..." + DateTime.Now);
                Thread.Sleep(5000);
                Console.WriteLine("Async Task 3 Completed!" + DateTime.Now);
            });
            Console.WriteLine("Heloo");
            await mytask;
        }
        public static async Task AsyncTask4()
        {
            Task mytask = Task.Run(() =>
            {
                Console.WriteLine("Async Task 4 Starting..." + DateTime.Now);
                Thread.Sleep(1000);
                Console.WriteLine("Async Task 4 Completed!" + DateTime.Now);
            });
            await mytask;
        }
        public static void AllTasks()
        {
            AsyncTask1();
            AsyncTask2();
            AsyncTask3();
            AsyncTask4();

        }
    }
}
