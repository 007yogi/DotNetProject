using Microsoft.AspNetCore.Mvc;
using OrderStore.Domain.Interfaces;
using OrderStore.Domain.Models;

namespace UnityOfWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _IProduct;
        public ProductController(IProduct IProduct)
        {
            _IProduct = IProduct;
        }

        [HttpPost(nameof(CreateProduct))]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            var result = await _IProduct.Add(product);
            if (result > 0)
                return Ok("Product Created");
            else
                return BadRequest("Error in Creating the Product");
        }

        [HttpGet(nameof(GetProductById))]        
        public async Task<IActionResult> GetProductById(int id)
        {
            var result = await _IProduct.Get(id);
            if (result is not null)
                return Ok(result);
            else return BadRequest("Error: data no");
        }

        [HttpGet(nameof(GetAllProduct))]
        public async Task<IActionResult> GetAllProduct()
        {
            var  result= await _IProduct.GetAll();
            return Ok(result);
        }

        /*[HttpPut(nameof(UpdateProduct))]
        public IActionResult UpdateProduct(Product product)
        {
            _IProduct.Update(product);
            return Ok("Product Updated");
        }*/
    }
}
