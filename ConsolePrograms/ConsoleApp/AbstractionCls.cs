using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class AbstractionCls
    {
        private int EmpId;
        private string EmpName;
        private double GrossPay;
        private double TaxDeduction = 0.1;
        private double NetSalary;

        public AbstractionCls(int id, string name, double grossPay)
        {
            this.EmpId = id;
            this.EmpName = name;
            this.GrossPay = grossPay;
        }
        private void CalculateSalary()
        {
            if (GrossPay >= 40000)
            {
                NetSalary = GrossPay - (TaxDeduction * GrossPay);
                Console.WriteLine("your salry is {0}", NetSalary);
            }
            else
            {
                Console.WriteLine("your salary is {0}", GrossPay);
            }
        }
        public void ShowDetails()
        {
            this.CalculateSalary();
        }
    }
}
