using ConsoleApp;
using ConsoleApp.Polymorphism;
using System;
using static ConsoleApp.Dotnet8;
public class Program
{
    public static void Main(string[] args)
    {
        /*Indexers*/
        //IndexerDemo stringData = new IndexerDemo();
        //stringData[0] = "One";
        //stringData[1] = "Two";
        //stringData[2] = "Three";
        //for (int i = 0; i < 5; i++)
        //{
        //    Console.WriteLine($"{stringData[i]}");
        //}


        //C# 12 new feature.
        //Student p2 = new Student("yogesh", 30, "school");
        //var age = p2.Age;
        //var name = p2.Name;
        //Console.WriteLine(age + name);

        //ReverseArray reverse = new ReverseArray();
        //reverse.ArrReverse();

        //EncodingDecoding.EncodingAndDecoding();

        //TwilioWhatsApp.WhatsAppMsg();

        //EncapsulationCls obj = new EncapsulationCls();
        //obj.setName("Yogesh");
        //obj.getName();
        //obj.setAge(20);
        //obj.getAge();

        //AbstractionCls obj = new AbstractionCls(1001, "Yogesh", 40000);
        //obj.ShowDetails();

        //MethodOverloading obj = new MethodOverloading();
        //obj.Add(2,4);

        //MethodOverriding obj = new ChildCls();
        //obj.Print();

        //Properties obj = new Properties("Kumar");        
        //Console.WriteLine(obj._lastName);
        //obj.StdId = 0;
        //obj.FirstName = "Test";
        //Console.WriteLine(obj.FirstName);

        //AbstractData obj1 = new AbstractData();
        //obj1.SId = 1001;
        //obj1.SName = "Test";
        //Console.WriteLine(obj1.SId);
        //Console.WriteLine(obj1.SName);

        /*------using statement -------*/
        using (var obj = new DisposePrint())
        {
            obj.PrintCSV();
        }

        /*-------------*/
        //DisposePrint obj = new DisposePrint();
        //try
        //{
        //    obj.PrintCSV();
        //}
        //finally
        //{
        //    ((IDisposable)obj).Dispose();
        //}
        /*-------------*/



        Console.ReadLine();
    }
}