using System.ComponentModel.DataAnnotations;
using KalaMarket.Resourses;

namespace KalaMarket.Web.Models.Account;

public class BaseLoginViewModel
{
    [Display(Name = nameof(PropertiesName.Email), ResourceType = typeof(PropertiesName))]
    [DataType(DataType.EmailAddress,
        ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = nameof(ErrorMessages.EmailType))]
    public string Email { get; set; }

    [Display(Name = nameof(PropertiesName.RePassword), ResourceType = typeof(PropertiesName))]
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessageResourceType = typeof(ErrorMessages)
        , ErrorMessageResourceName = nameof(ErrorMessages.NotSamePassword))]
    [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(ErrorMessages)
        , ErrorMessageResourceName = nameof(ErrorMessages.RequiredWithFieldName))]
    public string Password { get; set; }

    [Display(Name = nameof(PropertiesName.IsRemeberMe), ResourceType = typeof(PropertiesName))]
    public bool IsRemeberMe { get; set; }
}