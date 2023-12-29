using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    public class FactoryProgram
    {
        // Product interface
        interface IProduct
        {
            void Display();
        }

        // Concrete products
        class ConcreteProductA : IProduct
        {
            public void Display()
            {
                Console.WriteLine("This is Concrete Product A.");
            }
        }

        class ConcreteProductB : IProduct
        {
            public void Display()
            {
                Console.WriteLine("This is Concrete Product B.");
            }
        }

        // Factory interface
        interface IFactory
        {
            IProduct CreateProduct();
        }

        // Concrete factories
        class ConcreteFactoryA : IFactory
        {
            public IProduct CreateProduct()
            {
                return new ConcreteProductA();
            }
        }

        class ConcreteFactoryB : IFactory
        {
            public IProduct CreateProduct()
            {
                return new ConcreteProductB();
            }
        }

        class Client
        {
            public void DisplayProduct(IFactory factory)
            {
                IProduct product = factory.CreateProduct();
                product.Display();
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                Client client = new Client();

                IFactory factoryA = new ConcreteFactoryA();
                client.DisplayProduct(factoryA); // Displays "This is Concrete Product A."

                IFactory factoryB = new ConcreteFactoryB();
                client.DisplayProduct(factoryB); // Displays "This is Concrete Product B."

                Console.ReadKey();
            }
        }
    }
}
