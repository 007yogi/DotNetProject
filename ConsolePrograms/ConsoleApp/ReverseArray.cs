using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class ReverseArray
    {
        public void ArrReverse()
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            //var start = 0;
            //int end = arr.Length - 1;

            //while (start < end)
            //{
            //    int temp = arr[start];
            //    arr[start] = arr[end];
            //    arr[end] = temp;
            //    start++;
            //    end--;
            //}
            //foreach (var j in arr)
            //{
            //    Console.WriteLine(j);
            //}
            for (int i = arr.Length; i > 0; i--)
            {
                Console.WriteLine(i);
            }
        }

    }
}
