using System.ComponentModel.DataAnnotations;
using KalaMarket.Resourses;
using KalaMarket.Shared;

namespace KalaMarket.EndPoint.Models.Admin;

public class RegisterViewModel
{
    #region Properties

    // ************************************************************************************

    #region Attribute

    [DataType(DataType.EmailAddress, ErrorMessageResourceType =
        typeof(ErrorMessages), ErrorMessageResourceName = nameof(ErrorMessages.EmailType))]

    [Required(AllowEmptyStrings = false,
        ErrorMessageResourceType = typeof(ErrorMessages),
        ErrorMessageResourceName = nameof(ErrorMessages.RequiredWithFieldName))]
    [RegularExpression(KalaMarketConstants.RegularExpression.EmailAddress, ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = nameof(ErrorMessages.EmailType))]
    [Display(Name = nameof(PropertiesName.Email), ResourceType = typeof(PropertiesName))]
    #endregion Attribute

    public string Email { get; set; }
    // ************************************************************************************

    #region Attribute

    [Display(Name = nameof(PropertiesName.FullName), ResourceType = typeof(PropertiesName))]

    [Required(AllowEmptyStrings = false,
        ErrorMessageResourceType = typeof(ErrorMessages),
        ErrorMessageResourceName = nameof(ErrorMessages.RequiredWithFieldName))]



    #endregion

    public string FullName { get; set; }
    // ************************************************************************************

    #region Attribute
    [Display(Name = nameof(PropertiesName.Role), ResourceType = typeof(PropertiesName))]

    [Range(maximum: KalaMarketConstants.RoleId.Maximum, minimum: KalaMarketConstants.RoleId.Minimum
        , ErrorMessageResourceName = nameof(ErrorMessages.RoleUnvalid), ErrorMessageResourceType = typeof(ErrorMessages))]

    [Required(AllowEmptyStrings = false,
        ErrorMessageResourceType = typeof(ErrorMessages),
        ErrorMessageResourceName = nameof(ErrorMessages.RequiredWithFieldName))]


    #endregion Attribute
    public long RoleId { get; set; }
    // ************************************************************************************
    #region Attribute

    [Display(Name = nameof(PropertiesName.Password), ResourceType = typeof(PropertiesName))]
    [RegularExpression(pattern:KalaMarketConstants.RegularExpression.Password, ErrorMessageResourceName = nameof(ErrorMessages.UnValidPassword), ErrorMessageResourceType = typeof(ErrorMessages))]
    [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(ErrorMessages)
        , ErrorMessageResourceName = nameof(ErrorMessages.RequiredWithFieldName))]
    [DataType(DataType.Password)]

    [StringLength(maximumLength: KalaMarketConstants.MaxLength.Password, MinimumLength
        = KalaMarketConstants.MinLength.Password, ErrorMessageResourceName = nameof(ErrorMessages.OutofMinMax), ErrorMessageResourceType = typeof(ErrorMessages))]

    #endregion Attribute

    // ************************************************************************************

    public string Password { get; set; }
    // ************************************************************************************

    #region Atribute
    [Display(Name = nameof(PropertiesName.RePassword), ResourceType = typeof(PropertiesName))]
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessageResourceType = typeof(ErrorMessages)
        , ErrorMessageResourceName = nameof(ErrorMessages.NotSamePassword))]
    [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(ErrorMessages)
        , ErrorMessageResourceName = nameof(ErrorMessages.RequiredWithFieldName))]

    #endregion Atribute
    public string RePassword { get; set; }
    // ************************************************************************************

    #endregion Properties
}