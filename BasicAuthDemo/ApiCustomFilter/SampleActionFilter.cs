using Microsoft.AspNetCore.Mvc.Filters;

namespace ApiCustomFilter
{
    public class SampleActionFilter : Attribute, IActionFilter
    {
        private readonly string _name;

        public SampleActionFilter(string name)
        {
            _name = name;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"OnActionExecuting - {_name}");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"OnActionExecuted - {_name}");
        }

    }
}
