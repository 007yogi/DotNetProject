namespace UploadImage.Repository.Abastract
{
    public interface IFileService
    {
        public Tuple<int, string, string> SaveImage(IFormFile imageFile);
        public bool DeleteImage(string imgFileName);
    }
}
