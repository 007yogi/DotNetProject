using Microsoft.AspNetCore.Mvc;

namespace GenericRepo.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
