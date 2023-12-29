using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDemo
{
    public class YieldDemo
    {
        public static void Consumer()
        {
            foreach (int i in Integers())
            {
                Console.WriteLine(i.ToString());
            }
        }

        public static IEnumerable<int> Integers()
        {
            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    yield return i;
                }
            }
        }

        //static void Main(string[] args)
        //{
        //    //Consumer();
        //    //Console.ReadKey();

        //    string[] monthsofYear =
        //    {
        //        "January",
        //        "February",
        //        "March",
        //        "April",
        //        "May",
        //        "June",
        //        "July",
        //        "August",
        //        "September",
        //        "October",
        //        "November",
        //        "December"
        //    };

        //    //casted to ICollection  
        //    ICollection<string> collection = monthsofYear;
        //    (collection as string[])[2] = "Financial Month";
        //    if (!collection.IsReadOnly)
        //    {
        //        collection.Add("Financials");
        //    }
        //    else
        //    {
        //        Console.WriteLine("readonly collection");
        //    }
        //    foreach (var month in collection)
        //    {
        //        Console.WriteLine(month);
        //    }

        //    Console.ReadLine();
        //}

    }
}
