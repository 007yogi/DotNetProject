using ConstructorDemo;
using System.Text;

class Program
{
    public static void Main(string[] args)
    {
        //Employee employee = new Employee();

        //ChildClass C1 = new ChildClass("Yogesh", "Kumar", 30, "Teacher", 1200);
        //C1.Profile();

        //ParentClass p1 = new ParentClass("Yogesh", "Kumar", 30);
        //Console.WriteLine(p1.FirstName);

        //StaticConstuctor sc = new StaticConstuctor();
        //sc.GetDetails();
        //StaticConstuctor sc2 = new StaticConstuctor("Gurgaon");

        //CopyConstructor obj = new CopyConstructor("Yogesh", "Gurgaon");
        //obj.Getdata();
        //CopyConstructor obj2 = new CopyConstructor(obj);
        //obj2.Getdata();

        //PrivateConstructor obj = new PrivateConstructor();
        //PrivateConstructor.Getname("Yogesh");

        //ConstructorOverloading obj = new ConstructorOverloading("Hello", " India");

        //DestructorCls obj = new DestructorCls("Rahul", 25);
        //Console.WriteLine(obj.GetName());
        //Console.WriteLine(obj.GetAge());

        /* Constructor Overriding */

        //DerivedClass derivedObject1 = new DerivedClass();
        //derivedObject1.DisplayValue();
        //derivedObject1.DisplayDerivedValue();

        //Console.WriteLine("----------------------");

        DerivedClass derivedObject2 = new DerivedClass(30, 40);
        derivedObject2.DisplayValue();
        derivedObject2.DisplayDerivedValue();
        /* Constructor Overriding */

        Console.ReadKey();
    }
}
