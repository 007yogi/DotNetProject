using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Polymorphism
{
    public class MethodOverriding
    {
        public virtual void Print()
        {
            Console.WriteLine("this is base class method.");
        }
    }
    public class ChildCls : MethodOverriding
    {
        public override void Print()
        {
            base.Print();
            Console.WriteLine("this is child class method.");
        }
    }
}
