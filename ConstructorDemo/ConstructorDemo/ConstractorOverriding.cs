using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorDemo
{
    public class ConstractorOverriding
    {
    }
    public class BaseClass
    {
        private int baseValue;

        public BaseClass()
        {
            baseValue = 10;
            Console.WriteLine("BaseClass default constructor. {0}", baseValue);
        }

        public BaseClass(int value)
        {
            baseValue = value;
            Console.WriteLine("BaseClass parameterized constructor. {0}", baseValue);
        }

        public void DisplayValue()
        {
            Console.WriteLine($"BaseClass value: {baseValue}");
        }
    }

    public class DerivedClass : BaseClass
    {
        private int derivedValue;

        public DerivedClass() : base()
        {
            derivedValue = 20;
            Console.WriteLine("DerivedClass default constructor {0}", derivedValue);
        }

        public DerivedClass(int baseValue, int derivedValue) : base(baseValue)
        {
            this.derivedValue = derivedValue;
            Console.WriteLine("DerivedClass parameterized constructor. {0}", derivedValue);
        }

        public void DisplayDerivedValue()
        {
            Console.WriteLine($"DerivedClass value: {derivedValue}");
        }
    }
}
