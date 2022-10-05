using Microsoft.AspNetCore.Http;
using Myrmec;

namespace Shared.AspNetCore.CheckContentType;

public static class CheckTypeHelper
{
    static CheckTypeHelper()
    {
        // populate with mata data.
        Sniffer.Populate(ImageSupportedFiles);
    }
    // create a sniffer instance.
    private static Sniffer Sniffer = new Sniffer();
    // Supported Image Type
    private static List<Record> ImageSupportedFiles = new List<Record>
    {
        new Record("jpg,jpeg", "ff,d8,ff,E0"),
        new Record("jpg,jpeg", "ff,d8,ff,E1"),
        new Record("jpg,jpeg", "ff,d8,ff,E2"),
        new Record("jpg,jpeg", "ff,d8,ff,E8"),
        new Record("webp", "52,54,53,53"),
        new Record("webp", "57,45,42,50"),
        new Record("webp", "52,49,46,46"),
        new Record("png", "89,50,4e,47,0d,0a,1a,0a"),
    };
    /// <summary>
    /// Send IFormFile To Check File Is Supported Image Or Not
    /// </summary>
    /// <param name="file"></param>
    /// <returns>File is Image = true,Otherwise = False</returns>
    public static bool FileIsValidImage(this IFormFile file)
    {

        // get file head byte
        byte[] fileHead = ReadFileHead(file);
        // Start Check Match To Supported Image Type
        List<string> results = Sniffer.Match(fileHead);
        // Count > 0 Return True
        return Convert.ToBoolean(results.Count);
    }
    /// <summary>
    /// Read 20 Start Byte
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    private static byte[] ReadFileHead(IFormFile file)
    {
        using var fs = new BinaryReader(file.OpenReadStream());
        var bytes = new byte[20];
        fs.Read(bytes, 0, 20);
        return bytes;
    }
}