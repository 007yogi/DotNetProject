using UploadImage.Model;

namespace UploadImage.Repository.Abastract
{
    public interface IProductRepository
    {
        bool Add(Product model);
    }
}
