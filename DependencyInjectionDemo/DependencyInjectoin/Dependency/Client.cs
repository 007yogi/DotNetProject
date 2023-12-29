using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectoin.Dependency
{
    public class Client
    {
        private readonly IService _service;

        public Client(IService service)
        {
            _service = service;
        }
        public void ClientFun()
        {
            Console.WriteLine("service started.");
            _service.Serve();
        }

        public void MyFunction()
        {
            Console.WriteLine("This is my custom function.");
        }
    }
}
