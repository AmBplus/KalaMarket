using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace _01_Framework.AspCore.ValidateAttribute;

public class FileAcceptExtensionsAttribute : ValidationAttribute, IClientModelValidator
{
    private string[] ValidExtensions { get;  }
    public FileAcceptExtensionsAttribute(string[] validExtensions)
    {
        ValidExtensions = validExtensions;
    }
    
    public override bool IsValid(object? value)
    {
        if (value == null) return true;
        var file = value as IFormFile;
        if (file == null) return true;
        var fileExtension = Path.GetExtension(file.FileName);
        if (ValidExtensions.Contains(fileExtension)) return true;
        return false;
    }

    public void AddValidation(ClientModelValidationContext context)
    {
        context.Attributes.Add("data-val","true");
        context.Attributes.Add("data-val-ValidFileExtension",ErrorMessage);
    }
}