using Microsoft.AspNetCore.Mvc.Filters;
using System.Web.Http.Results;

namespace CustomAuth.Helper
{
    public class RoleRightAuthorization : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {      
            string userType = "Admin"; 
            Console.WriteLine("action executing");
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            //base.OnActionExecuted(context);
            Console.WriteLine("action executed");
        }
    }
}
