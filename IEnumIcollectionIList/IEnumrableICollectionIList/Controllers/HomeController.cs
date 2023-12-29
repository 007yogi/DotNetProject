using IEnumrableICollectionIList.Models;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Interface;
using System.Diagnostics;

namespace IEnumrableICollectionIList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISchool _Ischool;

        public HomeController(ILogger<HomeController> logger, ISchool Ischool)
        {
            _logger = logger;
            _Ischool = Ischool;
        }

        public IActionResult Index()
        {  
            School sc = new School();
            sc = _Ischool.SetSchoolData();

            return View(sc);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}