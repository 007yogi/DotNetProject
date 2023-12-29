using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UploadImage.Model;
using UploadImage.Repository.Abastract;
using UploadImage.Repository.Implementation;

namespace UploadImage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IFileService _fileService;
        private readonly IProductRepository _productRepo;

        public ProductController(IFileService fileService, IProductRepository productRepo)
        {
            _fileService = fileService;
            _productRepo = productRepo;
        }
        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct(Product model)
        {
            var status = new Status();
            if (!ModelState.IsValid)
            {
                status.StatusCode = 0;
                status.Message = "Please pass valid data.";
                return Ok(status);
            }
            if(model.ImageFile is not null)
            {
                var fileResult = _fileService.SaveImage(model.ImageFile);
                if(fileResult.Item1 == 1)
                {
                    model.ProductImage = fileResult.Item2; //getting the name of image.
                    model.ImagePath = fileResult.Item3;
                }
                var productResult = _productRepo.Add(model);
                if (productResult)
                {
                    status.StatusCode = 1;
                    status.Message = "Product added successfully.";
                }
                else
                {
                    status.StatusCode = 0;
                    status.Message = "Error on adding product.";
                }
            }
            return Ok(status);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteImage(string imgFileName)
        {
            _fileService.DeleteImage(imgFileName);
            return Ok();
        }
    }
}
