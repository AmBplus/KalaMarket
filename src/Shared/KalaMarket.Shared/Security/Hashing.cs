using System.Security.Cryptography;
using System.Text;

namespace KalaMarket.Shared.Security;

public static class Hashing
{
    public static string GetSha256(this string text)
    {
        var inputBytes =
            Encoding.UTF8.GetBytes(text);

        var sha =
            SHA256.Create();

        var outputBytes =
            sha.ComputeHash(inputBytes);

        sha.Dispose();
        //sha = null;

        var result =
            Convert.ToBase64String(outputBytes);

        return result;
    }
}