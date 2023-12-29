using CustomAuth.Helper;
using Microsoft.AspNetCore.Mvc;

namespace CustomAuth.Controllers
{
    public class BankController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [ServiceFilter(typeof(RoleRightAuthorization))]
        public IActionResult UserBankAccount()
        {
            return View();
        }
    }
}
