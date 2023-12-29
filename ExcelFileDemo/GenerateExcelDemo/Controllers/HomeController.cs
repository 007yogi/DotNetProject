using GenerateExcelDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GenerateExcelDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IExcelDemo _excelDemo;

        public HomeController(ILogger<HomeController> logger, IExcelDemo excelDemo )
        {
            _logger = logger;
            _excelDemo = excelDemo;
        }

        public IActionResult Index()
        {
            //_excelDemo.GenerateExcelFile();
            _excelDemo.ExportDynamicallyData();
            return View();
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