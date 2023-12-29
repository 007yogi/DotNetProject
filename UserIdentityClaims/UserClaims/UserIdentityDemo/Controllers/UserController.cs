using Microsoft.AspNetCore.Mvc;

namespace UserIdentityDemo.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Claims()
        {
            return View();
        }
    }
}
