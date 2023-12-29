using Product.API.DTO;

namespace Product.API.Mapper
{
    public static class ModelConvetor
    {
        public static Product.API.Entities.Product DtoToModel(ProductDto model)
        {
            return new Product.API.Entities.Product
            {
                Id = model.Id,
                Title = model.Title,
                Price = model.Price,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                CategoryId = model.CategoryId
            };
        }
        public static ProductDto ModelToDto(Product.API.Entities.Product dto)
        {
            return new ProductDto
            {
                Id = dto.Id,
                Title = dto.Title,
                Price = dto.Price,
                Description = dto.Description,
                ImageUrl = dto.ImageUrl,
                CategoryId = dto.CategoryId
            };
        }
    }
}
