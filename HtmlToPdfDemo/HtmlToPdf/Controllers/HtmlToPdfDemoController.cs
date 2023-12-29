using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using SelectPdf;

namespace HtmlToPdfApp.Controllers
{
    public class HtmlToPdfDemoController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private string pdfDir = string.Empty;

        public HtmlToPdfDemoController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult HtmlToPdfConverter()
        {
            SelectPdf.HtmlToPdf htmlToPdf = new SelectPdf.HtmlToPdf();

            string currentDir = Directory.GetCurrentDirectory();
            pdfDir = currentDir + "/PDF";

            string rootFolder = _webHostEnvironment.WebRootPath;
            string subfolderName = "dataFiles";
            string fileName = "itinerary.html";
            string filePath = Path.Combine(rootFolder, subfolderName, fileName);
            bool ispathExist = System.IO.File.Exists(filePath);
            if (ispathExist)
            {
                var htmlFile = System.IO.File.ReadAllText(filePath);
                var pdfFile = htmlToPdf.ConvertHtmlString(htmlFile.ToString());
                var savePdf = pdfFile.Save();
                var contentType = "application/pdf";                
                return File(savePdf, contentType, "sample.pdf");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
