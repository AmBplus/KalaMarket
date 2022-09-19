using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
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
        if (value is IFormFile file)
        {
            return IsValidFile(file);
        }
        else if(value is ICollection<IFormFile> files)
        {
            return IsValidFiles(files);
        }
        return false;
    }

    public bool IsValidFiles(ICollection<IFormFile> formFiles)
    {
        foreach (var file in formFiles)
        {
            if (!IsValidFile(file)) return false;
        }
        return true;
    }
    public bool IsValidFile(IFormFile file)
    {
        var fileExtension = Path.GetExtension(file.FileName);
        if (ValidExtensions.Contains(fileExtension)) return true;
        return false;
    }
    public void AddValidation(ClientModelValidationContext context)
    {
        string validEx = string.Empty;
        for (int i = 0; i < ValidExtensions.Length; i++)
        {
            if (i == ValidExtensions.Length - 1)
            {
                validEx += ValidExtensions[i];
            }
            else
            {
                validEx += $"{ValidExtensions[i]},";
                
            }
        }
        if (ErrorMessageResourceName != null)
        {
            context.Attributes.Add("data-val-ValidFileExtension", ErrorMessageResourceName);
        }
        else
        {
            context.Attributes.Add("data-val-ValidFileExtension", $" فرمت های صحیح فقط {validEx}");
        }
        context.Attributes.Add("accept",validEx);
    }
}