using UploadImage.Data;
using UploadImage.Model;
using UploadImage.Repository.Abastract;

namespace UploadImage.Repository.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Add(Product model)
        {
            bool result = false;
            try
            {
                _dbContext.ProductImage.Add(model);
                _dbContext.SaveChanges();
                return result = true;
            }
            catch (Exception ex)
            {
                return result;
            }
        }
    }
}
