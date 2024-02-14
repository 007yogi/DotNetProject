using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericConsoleDemo
{
    public class GenericProperty<T>
    {
        T box;
        public T Box 
        {
            set
            {
                this.box = value;
            }
            get
            {
                return this.box;
            }
        }

    }
}
