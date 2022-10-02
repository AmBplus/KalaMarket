using KalaMarket.Resourses;
using KalaMarket.Shared;
using System.ComponentModel.DataAnnotations;

namespace KalaMarket.EndPoint.Models.Account.Customer;

public class RegisterCustomerViewModel : BaseRegisterViewModel
{
    #region Properties

    // ************************************************************************************
    #region RoleIdAttribute
    [Display(Name = nameof(PropertiesName.Role), ResourceType = typeof(PropertiesName))]

    [Range(maximum: KalaMarketConstants.RoleId.Maximum, minimum: KalaMarketConstants.RoleId.Minimum
        , ErrorMessageResourceName = nameof(ErrorMessages.RoleUnvalid), ErrorMessageResourceType = typeof(ErrorMessages))]

    [Required(AllowEmptyStrings = false,
        ErrorMessageResourceType = typeof(ErrorMessages),
        ErrorMessageResourceName = nameof(ErrorMessages.RequiredWithFieldName))]


    #endregion /RoleIdAttribute
    public long RoleId { get; set; }
    // ************************************************************************************
    [Display(Name = "قوانین سایت")]
    [IsAcceptValidation(ErrorMessageResourceName = nameof(ErrorMessages.AcceptLaw), ErrorMessageResourceType = typeof(ErrorMessages))]
    public bool IsAcceptLaw { get; set; } = false;

    #endregion /RoleIdAttribute
}
