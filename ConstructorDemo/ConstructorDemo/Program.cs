using ConstructorDemo;

class Program
{
    public static void Main(string[] args)
    {
        //Employee employee = new Employee("Yogesh Kumar");
        ChildClass C1 = new ChildClass("Yogesh", "Kumar", 30, "Teacher", 1200);
        C1.Profile();
        Console.WriteLine("Called main method.");
        Console.ReadKey();
    }
}
