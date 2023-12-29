using Microsoft.EntityFrameworkCore;
using Product.API.Data;
using Product.API.DTO;
using Product.API.Mapper;

namespace Product.API.Services.Impementions
{
    public class ProductService : IProductService
    {
        private readonly ProductDbContext _dbContext;

        public ProductService(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ProductDto> CreateUpdateProductAsync(ProductDto productDto)
        {
            var product = ModelConvetor.DtoToModel(productDto);
            if (product.Id > 0)
            {
                _dbContext.products.Update(product);
            }
            else
            {
                _dbContext.products.Add(product);
            }
            await _dbContext.SaveChangesAsync();
            var dtoProduct = ModelConvetor.ModelToDto(product);
            return dtoProduct;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _dbContext.products.FirstOrDefaultAsync(p => p.Id == id);
            if (product is null)
            {
                return false;
            }
            _dbContext.products.Remove(product);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProduct()
        {
            var products = await _dbContext.products.Select(dto => new ProductDto
            {
                Id = dto.Id,
                Title = dto.Title,
                Price = dto.Price,
                Description = dto.Description,
                ImageUrl = dto.ImageUrl,
                CategoryId = dto.CategoryId
            }).ToListAsync();
            return products;
        }

        public async Task<ProductDto> GetProductById(int id)
        {
            var product = await _dbContext.products.Select(product => ModelConvetor.ModelToDto(product)).FirstOrDefaultAsync();
            return product;
        }
    }
}
