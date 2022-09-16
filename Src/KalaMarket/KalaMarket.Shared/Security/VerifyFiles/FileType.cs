namespace KalaMarket.Shared.Security.VerifyFiles;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

    public abstract class FileType
    {
        protected string Description { get; set; }
        protected string Name { get; set; }

        private List<string> Extensions { get; }
            = new List<string>();

        private List<byte[]> Signatures { get; }
            = new List<byte[]>();

        public int SignatureLength => Signatures.Max(m => m.Length);

        protected FileType AddSignatures(params byte[][] bytes)
        {
            Signatures.AddRange(bytes);
            return this;
        }

        protected FileType AddExtensions(params string[] extensions)
        {
            Extensions.AddRange(extensions);
            return this;
        }

        public FileTypeVerifyResult Verify(Stream stream)
        {
            stream.Position = 0;
            var reader = new BinaryReader(stream);
            var headerBytes = reader.ReadBytes(SignatureLength);

            return new FileTypeVerifyResult
            {
                Name = Name,
                Description = Description,
                IsVerified = Signatures.Any(signature =>
                    headerBytes.Take(signature.Length)
                        .SequenceEqual(signature)
                )
            };
        }
    }
    public class FileTypeVerifyResult
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsVerified { get; set; }
    }
public sealed class Jpeg : FileType
{
    public Jpeg()
    {
        Name = "JPEG";
        Description = "JPEG IMAGE";
        AddExtensions("jpeg", "jpg");
        AddSignatures(
            new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
            new byte[] { 0xFF, 0xD8, 0xFF, 0xE2 },
            new byte[] { 0xFF, 0xD8, 0xFF, 0xE3 }
        );
    }
}

public sealed class Mp3 : FileType
{
    public Mp3()
    {
        Name = "MP3";
        Description = "MP3 Audio File";
        AddExtensions("mp3");
        AddSignatures(
            new byte[] { 0x49, 0x44, 0x33 }
        );
    }
}

public sealed class Png : FileType
{
    public Png()
    {
        Name = "PNG";
        Description = "PNG Image";
        AddExtensions("png");
        AddSignatures(
            new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A }
        );
    }
}
public static class FileTypeVerifier
{
    private static FileTypeVerifyResult Unknown = new FileTypeVerifyResult
    {
        Name = "Unknown",
        Description = "Unknown File Type",
        IsVerified = false
    };

    static FileTypeVerifier()
    {
        Types = new List<FileType>
            {
                new Jpeg(),
                new Png(),
                new Mp3()
            }
            .OrderByDescending(x => x.SignatureLength)
            .ToList();
    }

    private static IEnumerable<FileType> Types { get; set; }

    public static FileTypeVerifyResult What(string path)
    {
        using var file = File.OpenRead(path);
        FileTypeVerifyResult result = null;

        foreach (var fileType in Types)
        {
            result = fileType.Verify(file);
            if (result.IsVerified)
                break;
        }

        return result?.IsVerified == true
            ? result
            : Unknown;
    }
}
