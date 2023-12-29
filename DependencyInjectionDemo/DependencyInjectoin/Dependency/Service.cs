using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectoin.Dependency
{
    public class Service : IService
    {
        public void Serve()
        {
            Console.WriteLine("this is serving method.");
        }
    }
}
