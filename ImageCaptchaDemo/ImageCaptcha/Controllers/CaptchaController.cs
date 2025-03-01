using Microsoft.AspNetCore.Mvc;
using System.Drawing.Imaging;
using System.Drawing;

namespace ImageCaptcha.Controllers
{
    public class CaptchaController : Controller
    {
        private readonly IConfiguration _config;

        public CaptchaController(IConfiguration config)
        {
            this._config = config;
        }
        [HttpGet]
        public IActionResult GenerateCaptcha()
        {
            // Generate random CAPTCHA text
            string captchaText = GenerateRandomText(6);

            // Store the CAPTCHA text in session
            HttpContext.Session.SetString("CaptchaCode", captchaText);

            // Generate the CAPTCHA image
            byte[] captchaImage = GenerateCaptchaImage(captchaText);

            // Return the image as a File (PNG format)
            return File(captchaImage, "image/png");
        }

        private string GenerateRandomText(int length)
        {
            string chars = _config.GetSection("CaptchaText:Captcha").Value;
            
            var random = new Random();
            char[] stringChars = new char[length];

            for (int i = 0; i < length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new string(stringChars);
        }

        private byte[] GenerateCaptchaImage(string captchaText)
        {
            using (Bitmap bitmap = new Bitmap(250, 80))
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                Random rand = new Random();
                graphics.Clear(Color.LightGray);

                // Set font and brush for the CAPTCHA text
                Font font = new Font("Arial", 40, FontStyle.Bold);
                Brush brush = new SolidBrush(Color.Black);

                // Draw the CAPTCHA text
                graphics.DrawString(captchaText, font, brush, 10, 10);

                // Add random noise (optional)
                for (int i = 0; i < 10; i++)
                {
                    //int x = rand.Next(0, bitmap.Width);
                    //int y = rand.Next(0, bitmap.Height);
                    //bitmap.SetPixel(x, y, Color.Black);

                    Pen pen = new Pen(GetRandomColor(rand), 2);
                    int x1 = rand.Next(0, bitmap.Width);
                    int y1 = rand.Next(0, bitmap.Height);
                    int x2 = rand.Next(0, bitmap.Width);
                    int y2 = rand.Next(0, bitmap.Height);
                    graphics.DrawLine(pen, x1, y1, x2, y2);
                }

                // Save the image to a memory stream
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    bitmap.Save(memoryStream, ImageFormat.Png);
                    return memoryStream.ToArray();
                }
            }
        }
        private Color GetRandomColor(Random rand)
        {
            // Generate a random color
            int r = rand.Next(0, 256);
            int g = rand.Next(0, 256);
            int b = rand.Next(0, 256);
            return Color.FromArgb(r, g, b);
        }
    }
}
