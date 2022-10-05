using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Shared.AspNetCore.ValidateAttribute;

public class MaxSizeFileAttribute : ValidationAttribute, IClientModelValidator
{

    private int MaxSize { get; }
    public MaxSizeFileAttribute(int maxSize)
    {
        MaxSize = maxSize;
    }

    public override bool IsValid(object? value)
    {
        if (value == null) return true;
        var file = value as IFormFile;
        if (file == null) return true;
        if (file.Length < MaxSize) return true;
        return false;
    }

    public void AddValidation(ClientModelValidationContext context)
    {
        context.Attributes.Add("data-val", "true");
        context.Attributes.Add("data-val-MaxFileSize", $" حداکثر فایل اپلودی باید{MaxSize / (1024)}کیلو بایت باشد ");
    }
}