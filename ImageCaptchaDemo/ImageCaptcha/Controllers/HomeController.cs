using ImageCaptcha.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ImageCaptcha.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ValidateCaptcha(string captchaInput)
        {
            // Retrieve the CAPTCHA code stored in the session
            string captchaCode = HttpContext.Session.GetString("CaptchaCode");

            if (captchaInput == captchaCode)
            {
                ViewBag.Message = "CAPTCHA validation succeeded!";
            }
            else
            {
                ViewBag.Message = "CAPTCHA validation failed!";
            }

            return View("Index");
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
