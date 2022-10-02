using _01_Framework.AspCore.CheckContentType;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace _01_Framework.AspCore.Utility;

public static class SaveFileHelper
{
    public static async Task<string> SaveFormFile(this IFormFile file, IHostingEnvironment hostEnvironment,
        string path, string fileExtension)
    {
        if (file != null && file.Length > 0)
        {
            var relativePath = Path.Combine(path,
                Guid.NewGuid().ToString()) + fileExtension;
            var absolutePath = hostEnvironment.WebRootPath + Path.DirectorySeparatorChar + relativePath;
            var directoryPath = Path.GetDirectoryName(absolutePath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            using (var stream = System.IO.File.Create(absolutePath))
            {
                await file.CopyToAsync(stream);
            }
            return relativePath;
        }
        return null;
    }
    public static async Task<IList<string>> SaveRangeFormFile(this IList<IFormFile> files, IHostingEnvironment hostEnvironment,
        string relativePath)
    {
        IList<string> imagePath = new List<string>();
        foreach (var image in files)
        {
            if (image.FileIsValidImage())
            {
                var extension = Path.GetExtension(image.FileName);
                var fileName = await image.SaveFormFile(hostEnvironment, relativePath, extension);
                if (!string.IsNullOrWhiteSpace(fileName))
                {
                    imagePath.Add(fileName);
                }
            }
        }
        return imagePath;
    }

}