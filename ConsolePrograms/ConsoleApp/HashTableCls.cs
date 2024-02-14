using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class HashTableCls
    {
        public void hashTableData()
        {
            //Hashtable ht = new Hashtable()
            //{
            //    {"Id", 123},
            //    {"Name", "Amit" },
            //    {"Salary", 12000 }
            //};
            //Console.WriteLine(ht["Salary"]);

            Hashtable ht = new Hashtable();
            ht.Add("Id", 1001);
            ht.Add("Name", "Rahul Kumar");
            ht.Add("Salary", 10000.00);
            ht.Add("Designation", "Manager");            

            foreach (object key in ht.Keys)
            {
                //Console.WriteLine(key + ":" + ht[key]);
            }

            Console.WriteLine("-----------------------");            
            foreach (object key in ht.Keys)
            {
                //Console.WriteLine(key + ":" + ht[key]);
            }
            Console.WriteLine(ht.Contains("Salary"));
        }
    }
}
