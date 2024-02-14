using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericConsoleDemo
{
    public class GenericCls1<T>
    {
        T box;
        public GenericCls1(T a)
        {
            this.box = a;
        }
        public T GetValue()
        {
            return this.box;
        }
    }
}
