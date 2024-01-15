using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public abstract class AbstractCls
    {
        public string FirstName;
        public string LastName;
        public int Age;
        public string Address;
        public abstract void PrintDetails();
        public void division()
        {
            int a, b;
            a = 10;
            b = 20;
            Console.WriteLine("Diveision is : " + b / a);
        }
    }
    public class Student2 : AbstractCls
    {
        public int RollNo;
        public int Fees;

        public override void PrintDetails()
        {
            string name = this.FirstName + " " + this.LastName;
            Console.WriteLine("Student Name is: {0}", name);
            Console.WriteLine("Student Age is: {0}", this.Age);
            Console.WriteLine("Student Address is: {0}", this.Address);
            Console.WriteLine("Student RollNo is: {0}", this.RollNo);
            Console.WriteLine("Student Fee is: {0}", this.Fees);
        }
    }
    public class Teacher : AbstractCls
    {
        public int Salary;
        public string Qualification;
        public override void PrintDetails()
        {
            string name = this.FirstName + " " + this.LastName;
            Console.WriteLine("Teacher Name is: {0}", name);
            Console.WriteLine("Teacher Age is: {0}", this.Age);
            Console.WriteLine("Teacher Address is: {0}", this.Address);
            Console.WriteLine("Teacher Salary is: {0}", this.Salary);
            Console.WriteLine("Teacher Qualification is: {0}", this.Qualification);
        }
    }
}
