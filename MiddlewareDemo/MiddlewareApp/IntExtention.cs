namespace MiddlewareApp
{
    public static class IntExtention
    {
        public static int CustomIntExtention(this int x)
        {
            return x + 100;
        }
    }

    public static class StringExtensions
    {
        public static string CustomStringExtension(this string str)
        {
            // Your custom logic here
            return "Custom: " + str;
        }
    }

}
