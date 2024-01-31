using ConsoleApp;
using ConsoleApp.Polymorphism;
using System;
using static ConsoleApp.Dotnet8;
public class Program
{
    /*public static void Main(string[] args)
    {*/
        /*Indexers*/

        //IndexerDemo stringData = new IndexerDemo();
        //stringData[0] = "One";
        //stringData[1] = "Two";
        //stringData[2] = "Three";
        //for (int i = 0; i < 5; i++)
        //{
        //    Console.WriteLine($"{stringData[i]}");
        //}

        /* C# 12 new feature. */

        //Student p2 = new Student("yogesh", 30, "school");
        //var age = p2.Age;
        //var name = p2.Name;
        //Console.WriteLine(age + name);

        //ReverseArray reverse = new ReverseArray();
        //reverse.ArrReverse();

        //EncodingDecoding.EncodingAndDecoding();

        //TwilioWhatsApp.WhatsAppMsg();

        /* Encapsulation */

        //EncapsulationCls obj = new EncapsulationCls();
        //obj.setName("Yogesh");
        //obj.getName();
        //obj.setAge(20);
        //obj.getAge();

        /* Abstraction */

        //AbstractionCls obj = new AbstractionCls(1001, "Yogesh", 40000);
        //obj.ShowDetails();

        /* MethodOverloading */

        //MethodOverloading obj = new MethodOverloading();
        //obj.Add(2,4);

        //MethodOverriding obj = new ChildCls();
        //obj.Print();

        /* Properties */

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

        //using (var obj = new DisposePrint())
        //{
        //    obj.PrintCSV();
        //}

        /*-----Dispose--------*/
        //DisposePrint obj = new DisposePrint();
        //try
        //{
        //    obj.PrintCSV();
        //}
        //finally
        //{
        //    ((IDisposable)obj).Dispose();
        //}

        /*-----use Ref--------*/

        //int number = 5;
        //Console.WriteLine("old value is: {0}", number);
        //RefAndOutCls.ModifyValueByRef(ref number);
        //Console.WriteLine("updated value is: {0}", number);

        /*--------use Out--------*/
        //int number;
        //RefAndOutCls.InitializeAndModify(out number);
        //Console.WriteLine("value is: {0}", number);

        /* Abstruct class */
        //Student2 obj = new Student2();
        //obj.FirstName = "Yogesh";
        //obj.LastName = "Kumar";
        //obj.Age = 30;
        //obj.Address = "Delhi";
        //obj.RollNo = 1223435667;
        //obj.Fees = 10000;
        //obj.PrintDetails();

        //object a = new int[] { 123, 345 };
        //bool z = a is int[];
        //Console.WriteLine(z);
        //int[] str = a as int[];
        //Console.WriteLine(str);

        /* diff b/w '== ' and Equals() method */

        //object o1 = "Hello India";
        //object o2 = new string("Hello India".ToCharArray());
        //Console.WriteLine(o1 == o2); // compare object reference
        //Console.WriteLine(o1.Equals(o2) + "\n Obj1: " + o1.GetType() + "\n Obj2: " + o2.GetType()); // compare content

        /*Console.ReadLine();
    }*/
}