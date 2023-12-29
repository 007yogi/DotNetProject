using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Principal;
using System.Text;

namespace BasicAuth.BasicAuth
{
    public class BasicAuthenticationAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            bool authorization = true;
            if (!context.HttpContext.Request.Headers.ContainsKey("Authorization"))
            {
                authorization = false;
            }
            string authorizationHeader = context.HttpContext.Request.Headers["Authorization"].ToString();
            if (string.IsNullOrEmpty(authorizationHeader))
            {
                authorization = false;
            }
            if(authorization == true)
            {
                // username:password base64 encoded.
                //  admin:admin@123
                string token = string.Empty;
                token = authorizationHeader.Substring(6);
                string decodedAuthToken = Encoding.UTF8.GetString(Convert.FromBase64String(token));

                string[] usernamePass = decodedAuthToken.Split(':');
                string username = usernamePass[0];
                string password = usernamePass[1];

                if (ValidateUser.Login(username, password))
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(username), null);
                }
                else
                {
                    context.ModelState.AddModelError("Unauthorized", "you are not authorized");
                    context.Result = new UnauthorizedObjectResult(context.ModelState);
                }
            }
            else
            {
                context.ModelState.AddModelError("Unauthorized", "you are not authorized");
                context.Result = new UnauthorizedObjectResult(context.ModelState);
            }
           
        }
    }
}
