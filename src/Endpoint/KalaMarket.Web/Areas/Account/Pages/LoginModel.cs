using System.Security.Claims;
using KalaMarket.Application.Identity.Services.Users.FacadePattern;
using KalaMarket.Application.Identity.Services.Users.Queries.GetUsers.Dto;
using KalaMarket.Resourses;
using KalaMarket.Shared;
using KalaMarket.Shared.Security;
using KalaMarket.Web.Models.Account.Customer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Shared.AspNetCore.Infrastructure;
using Shared.AspNetCore.Infrastructure.Security;

namespace KalaMarket.Web.Areas.Account.Pages;

public class LoginModel : BasePageModel
{
    #region Constructor

    public LoginModel(IUserAggFacadeService userAggService)
    {
        UserAggService = userAggService;
    }

    #endregion /Constructor

    #region Properties

    [BindProperty] public LoginCustomerViewModel LoginViewModel { get; set; }

    private IUserAggFacadeService UserAggService { get; }

    #endregion /Properties


    #region Methods

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost()
    {
        if (!ModelState.IsValid) return Page();
        // Get UserResult
        var userResult = UserAggService.UserQuery.GetUserWithRolesService.Execute(new RequestGetUserWithRolesDto
        {
            Email = LoginViewModel.Email,
            Password = LoginViewModel.Password
        });
        // Check User Result
        if (!userResult.IsSuccess)
        {
            ModelState.AddModelError("", userResult.Message);
            AddToastError(userResult.Message);
            return Page();
        }

        var hashPassword = LoginViewModel.Password.GetSha256();
        // Check Password
        var isSamePassword = string.Compare(hashPassword, userResult.Data.Password, false);
        if (isSamePassword < 0)
        {
            ModelState.AddModelError("", ErrorMessages.WrongEmailOrPassword);
            AddToastError(ErrorMessages.WrongEmailOrPassword);
            return Page();
        }

        // LoginUser
        return await LoginCustomerViewModel(userResult.Data);
    }

    private async Task<IActionResult> LoginCustomerViewModel(GetUserWithRoleDto loginDto)
    {
        // Create Claims
        var claims = new List<Claim>
        {
            new(ClaimTypes.Email, loginDto.Email),
            new(ClaimTypes.NameIdentifier, loginDto.Id.ToString()),
            new(ClaimTypes.Name, !string.IsNullOrWhiteSpace(loginDto.FullName) ? loginDto.FullName : loginDto.Email)
        };
        foreach (var role in loginDto.Role) claims.Add(new Claim(ClaimTypes.Role, role));

        // Add Clams To ClaimIdentity
        var claimIdentity = new ClaimsIdentity(claims, SecurityUtility.AuthenticationScheme);
        // Create AuthConfiguration
        var authProperties = new AuthenticationProperties
        {
            AllowRefresh = true,
            IsPersistent = LoginViewModel.IsRemeberMe,
            IssuedUtc = Utility.Now
        };
        // Try Signin
        await HttpContext.SignInAsync(SecurityUtility.AuthenticationScheme,
            new ClaimsPrincipal(claimIdentity), authProperties);
        return Redirect("/Site");
    }

    #endregion /Methods
}