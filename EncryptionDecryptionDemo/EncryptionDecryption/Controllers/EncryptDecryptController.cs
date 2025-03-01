using EncryptionDecryption.AESMgmt;
using Microsoft.AspNetCore.Mvc;

namespace EncryptionDecryption.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncryptDecryptController : ControllerBase
    {
        private readonly EncryptDecryptService _encryptDecryptService;
        public EncryptDecryptController(EncryptDecryptService encrypt)
        {
            this._encryptDecryptService = encrypt;
        }

        [HttpPost("encrypt")]
        public IActionResult EncryptData(string plainText)
        {
            if (string.IsNullOrEmpty(plainText))
            {
                return BadRequest("input text is required.");
            }
            var encryptedData = _encryptDecryptService.EncryptString(plainText);
            return Ok(new { encryptedData });
        }

        [HttpPost("decrypt")]
        public IActionResult DecryptData(string cipherText)
        {
            if (string.IsNullOrEmpty(cipherText))
            {
                return BadRequest("encrypt text is required.");
            }
            try
            {
                var decryptedData = _encryptDecryptService.DecryptString(cipherText);
                return Ok(new { decryptedData });
            }
            catch (Exception ex)
            {
                return BadRequest($"Error decrypt data: {ex.Message}");
            }
        }
    }
}
