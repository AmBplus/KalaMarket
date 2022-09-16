using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;

namespace _01_Framework.AspCore.Utility;

public static class SaveFileHelper
{
    public static async Task<string> SaveFormFile(this IFormFile file,string path,string fileExtension)
    {
        if (file.Length > 0)
        {
            var filePath = Path.Combine(path,
                Guid.NewGuid().ToString());
            filePath += fileExtension;
            using (var stream = System.IO.File.Create(filePath))
            {
                await file.CopyToAsync(stream);
            }
            return Path.GetFileName(filePath);
        }
        return null;
    }
}