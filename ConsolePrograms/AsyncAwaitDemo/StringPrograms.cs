using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitDemo
{
    public class StringPrograms
    {
        public static void CompareStrings()
        {
            string str1 = "Hello";
            string str2 = "Hello";

            bool areEqual = CompareFunction(str1, str2);
            if (areEqual)
            {
                Console.WriteLine($"{str1} and {str2} are equal.");
            }
            else
            {
                Console.WriteLine($"{str1} and {str2} are not equal.");
            }
        }
        private static bool CompareFunction(string str1, string str2)
        {
            if(str1.Length != str2.Length)
            {
                return false;
            }
            for (int i =0; i < str1.Length; i++)
            {
                if (str1[i] != str2[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
