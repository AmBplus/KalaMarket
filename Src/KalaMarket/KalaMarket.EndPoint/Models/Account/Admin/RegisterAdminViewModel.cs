using KalaMarket.Resourses;
using KalaMarket.Shared;
using System.ComponentModel.DataAnnotations;

namespace KalaMarket.EndPoint.Models.Account.Admin;

public class RegisterAdminViewModel : BaseRegisterViewModel
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

    #endregion Properties
}