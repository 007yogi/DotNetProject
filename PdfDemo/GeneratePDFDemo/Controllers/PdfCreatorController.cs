using GeneratePDFDemo.Utility;
using Microsoft.AspNetCore.Mvc;
using SelectPdf;

namespace GeneratePDFDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PdfCreatorController : ControllerBase
    {
        private readonly TemplateGenerator _templateGenerator;
        private string pdfDir = string.Empty;
        public PdfCreatorController(TemplateGenerator templateGen)
        {
            var currentDir = Directory.GetCurrentDirectory();
            pdfDir = currentDir + "/PDF";
            if (!Directory.Exists(pdfDir))
            {
                Directory.CreateDirectory(pdfDir);
            }

            _templateGenerator = templateGen;
        }
        [HttpGet]
        public IActionResult CreatePDF()
        {
            HtmlToPdf htmlToPdf = new HtmlToPdf();
            var doc = htmlToPdf.ConvertHtmlString(_templateGenerator.GetHTMLString());
            doc.Save(pdfDir + "/Sample.pdf");
            doc.Close();
            return Ok("Successfully created PDF document.");
        }
    }
}
