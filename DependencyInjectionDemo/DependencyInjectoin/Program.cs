using DependencyInjectoin;
using DependencyInjectoin.Dependency;
using DependencyInjectoin.SimpleDependency;
using System;

class Program
{
    // Main Method
    static public void Main(String[] args)
    {
        Console.WriteLine("Main Method");
        // dependency injection.
        Client c1 = new Client(new Service());
        c1.ClientFun();
        c1.MyFunction();

        // Simple dependency injection call.
        /*Student s1 = new ();
        s1.StudentName();*/

        Console.ReadKey();
    }
}