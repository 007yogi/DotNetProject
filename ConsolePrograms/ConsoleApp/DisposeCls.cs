using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class DisposeCls : IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("This is Dispose() method.");
        }
    }
    public class DisposePrint : DisposeCls
    {
        public new void Dispose()
        {
            Console.WriteLine("This is DisposePrint() method.");
        }
        public void PrintCSV()
        {
            Console.WriteLine("This is PrintCSVc() method.");
        }
    }
}
