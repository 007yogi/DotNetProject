using ConsoleApp;
using System;
using static ConsoleApp.Dotnet8;
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Main method started.");

        /*Indexers*/
        //IndexerDemo stringData = new IndexerDemo();
        //stringData[0] = "One";
        //stringData[1] = "Two";
        //stringData[2] = "Three";
        //for (int i = 0; i < 5; i++)
        //{
        //    Console.WriteLine($"{stringData[i]}");
        //}


        //C# 12 feature.
        //Student p2 = new Student("yogesh", 30, "school");
        //var age = p2.Age;
        //var name = p2.Name;
        //Console.WriteLine(age + name);

        ReverseArray reverse = new ReverseArray();
        reverse.ArrReverse();

        Console.ReadLine();
    }
}