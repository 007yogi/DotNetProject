using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class RefAndOutCls
    {
        public static void ModifyValueByRef(ref int a)
        {
            a = a * 2;
        }

        public static void InitializeAndModify(out int x)
        {
            x = 12;
            x = x * 2;
        }
    }
}
