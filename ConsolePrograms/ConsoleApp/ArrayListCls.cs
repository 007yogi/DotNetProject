using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class ArrayListCls
    {
        public static void ArrayListDemo()
        {
            ArrayList al = new ArrayList(); 
            al.Add(1);
            al.Add("Geeta");
            al.Add(10000.00);
            Console.WriteLine(al.Capacity);
            Console.WriteLine(al[2]);
        }
    }
}
