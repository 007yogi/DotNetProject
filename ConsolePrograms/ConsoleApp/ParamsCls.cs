using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class ParamsCls
    {
        public static int ParamsDemoFun(params int[] nums)
        {
            int sum = 0;
            foreach (int i in nums)
            {
                sum = sum + i;
            }
            return sum;
        }
    }
}
