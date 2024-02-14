namespace GenericConsoleDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3 };
            string[] str = { "A", "B", "C", "D" };
            double[] pointsArr = { 2.3, 4.6, 5.8 };

            //GenericMethods.ShowArray(arr);
            //GenericMethods.ShowArray(str);
            //GenericMethods.ShowArray(pointsArr);

            //Console.WriteLine(GenericMethods.CheckValue(10, 10));
            //Console.WriteLine(GenericMethods.CheckValue("ABC", "ABC"));
            //Console.WriteLine(GenericMethods.CheckValue2("AA", b: "yogesh"));

            //GenericCls1<int> obj = new GenericCls1<int>(10);
            /*GenericCls1<string> obj2 = new GenericCls1<string>("Yogesh");
            Console.WriteLine(obj2.GetValue());*/

            GenericProperty<int> obj = new GenericProperty<int>();
            Console.WriteLine(obj.Box = 10);


            Console.ReadKey();
        }
    }
}
