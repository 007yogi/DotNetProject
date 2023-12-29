using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitDemo
{
    public class FindEvenConstant
    {
        public static void FindConstant()
        {
            string str = "ybgeshkumar123";
            var arrLeng = str.Length;
            var count = 0;
            for (int i = 0; i < arrLeng; i++)
            {
                char ch = str[i];
                if (char.IsLetter(ch))
                {
                    if (str[i] == 'a' || str[i] == 'e' || str[i] == 'i' || str[i] == 'o' || str[i] == 'u')
                    {
                        Console.WriteLine(str[i] + " => is vowel");
                    }
                    else if (i % 2 == 0)
                    {
                        Console.WriteLine(str[i] + " => is constant");
                        count++;
                    }
                }

            }
            Console.WriteLine("total constant=" + count);
        }

        public static void FindCharAndNumber()
        {
            string[] strings = { "123443", "Banana5", "Orange8", "PineApple", "Grapes" };
            foreach (var str in strings)
            {
                if (str.Any(c => char.IsDigit(c)) && (str.Any(char.IsLetter)))
                {
                    Console.WriteLine(str);
                }
            }
        }

        public static void RemoveDuplicate()
        {
            string inputString = "apppleee";
            var length = inputString.Length;
            string resultString = string.Empty;

            for (int i = 0; i < length; i++)
            {
                if (!resultString.Contains(inputString[i]))
                {
                    resultString += inputString[i];
                }
            }
            Console.WriteLine(resultString);
        }

        public static void CountDuplicateChar()
        {
            String str = "aaabbcddeff";
            Dictionary<char, int> count = new Dictionary<char, int>();

            for (int i = 0; i < str.Length; i++)
            {
                if (count.ContainsKey(str[i]))
                {
                    int temp = count[str[i]];
                    count.Remove(str[i]);
                    count.Add(str[i], temp + 1);
                }
                else count.Add(str[i], 1); 
            }

            //var newVal = count.Aggregate((x,y)=>x.Value >y.Value ? x : y);
            //Console.WriteLine(newVal);
            
            foreach (var item in count)
            {
                Console.WriteLine(item.Value + item.Key.ToString());
            }
        }
    }
}
