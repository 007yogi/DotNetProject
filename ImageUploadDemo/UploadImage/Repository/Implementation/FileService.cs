using Microsoft.OpenApi.Expressions;
using System.Security.AccessControl;
using UploadImage.Repository.Abastract;

namespace UploadImage.Repository.Implementation
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _webHost;

        public FileService(IWebHostEnvironment webHost)
        {
            _webHost = webHost;
        }

        public bool DeleteImage(string imgFileName)
        {
            var rootPath = _webHost.ContentRootPath;
            var path = Path.Combine(rootPath,"Uploads\\", imgFileName);
            if (File.Exists(path))
            {
                File.Delete(path);
                return true;
            }
            return false;
        }

        public Tuple<int, string, string> SaveImage(IFormFile imageFile)
        {
            try
            {
                var contentPath = _webHost.ContentRootPath;
                var path = Path.Combine(contentPath, "Uploads");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                // check the allowed extensions.
                var ext = Path.GetExtension(imageFile.FileName);
                var allowedExt = new string[] { ".jpeg", ".png", "jpg" };
                if (!allowedExt.Contains(ext))
                {
                    string msg = string.Format("Only {0} extensions are allowed.", string.Join(",", allowedExt));
                    return new Tuple<int, string, string>(0, msg, "");
                }
                DateTime indianTime = DateTime.UtcNow.AddHours(5.5);
                string file_name = Path.Combine(path, "img-" + indianTime.ToString("ddMMMyyyy") + ext);

                string uniqueString = Guid.NewGuid().ToString();
                var newFileName = uniqueString + ext;

                var uploadFolder = Path.GetFileName(path);  // get upload folder.
                var uploadPath = Path.Combine(uploadFolder, newFileName);

                var fileWithPath = Path.Combine(path, newFileName);
                if (File.Exists(fileWithPath))
                {
                    File.Delete(fileWithPath); // delete image if exist.
                }
                var stream = new FileStream(fileWithPath, FileMode.Create);
                imageFile.CopyTo(stream);
                stream.Close();
                //return new Tuple<int, string, string>(1, newFileName, uploadPath);
                return Tuple.Create(1, newFileName, uploadPath);
            }
            catch (Exception ex)
            {
                //return new Tuple<int, string, string>(0, "Error has occured", "");
                return Tuple.Create(0, "Error has occured", "");
            }
        }
    }
}
