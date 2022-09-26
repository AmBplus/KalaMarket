using Microsoft.AspNetCore.Hosting;

namespace _01_Framework.AspCore.Utility;

public static class RemoveFileHelper
{
    public static async Task RemoveFile(IHostingEnvironment hostEnvironment, string path)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            var absolutePath = hostEnvironment.WebRootPath + path;
            if (File.Exists(absolutePath))
                File.Delete(absolutePath);
        }
    }
    public static async Task RemoveRangeFiles(IHostingEnvironment hostEnvironment, IList<string> pathFiles)
    {
        foreach (var pathFile in pathFiles)
        {
            await RemoveFile(hostEnvironment, pathFile);
        }
    }
}