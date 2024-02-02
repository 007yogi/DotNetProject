using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class IsAndAsOperatorCls
    {
        /* used to check the datatype of an object. */
        public void IsOperatorFun()
        {
            object name = "Yogesh";
            bool check = name is string;
            if (check)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }

        /* check the compatibilty of one object type with another object type. */
        public void AsOperatorFun()
        {
            object name = "Yogesh";
            string str = name as string;
            Console.WriteLine(str);
        }

        public void NullCaolesceOperator()
        {
            string Name = "Yogesh";
            string Result = string.Empty;

            string Result2 = Name ?? "Kumar";
            Console.WriteLine(Result2);

            //if(Name != null)
            //{
            //    Result = Name;
            //    Console.WriteLine(Result);
            //}



        }
    }
}
