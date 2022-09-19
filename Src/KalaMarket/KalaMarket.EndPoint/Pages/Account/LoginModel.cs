using KalaMarket.Resourses;
using Task = System.Threading.Tasks.Task;
using KalaMarket.EndPoint.Infrastructure;
using KalaMarket.EndPoint.Models.Account.Customer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using KalaMarket.Application.User.Services.Users.FacadePattern;
using KalaMarket.Application.User.Services.Users.Queries.GetUsers.Dto;
using KalaMarket.Application.User.Services.Users.Queries.GetUsers.Interfaces;
using Utility = KalaMarket.EndPoint.Infrastructure.Security.Utility;

namespace KalaMarket.EndPoint.Pages.Account
{
    public class LoginModel : BasePageModel
    {
        #region Constructor

        public LoginModel(IUserFacadeService userService)
        {
            UserService = userService;
        }

        #endregion /Constructor

        #region Properties

        [BindProperty]
        public LoginCustomerViewModel LoginViewModel { get; set; }
        private IUserFacadeService UserService { get; }

        #endregion /Properties


        #region Methods
        public void OnGet()
        {
        }

        public async Task OnPost()
        {
            if(!ModelState.IsValid)return;
            // Get UserResult
            var userResult =  UserService.UserQuery.GetUserWithRolesService.Execute(new RequestGetUserWithRolesDto()
            {
                Email = LoginViewModel.Email,
                Password = LoginViewModel.Password
            });
            // Check User Result
            if (!userResult.IsSuccess)
            {
                ModelState.AddModelError("", userResult.Message);
                AddToastError(userResult.Message);
                return;
            }
            // Check Password
            var isSamePassword = string.Compare(LoginViewModel.Password, userResult.Data.Password,ignoreCase: false);
            if (isSamePassword == 0)
            {
                ModelState.AddModelError("", errorMessage:ErrorMessages.WrongEmailOrPassword);
                AddToastError(ErrorMessages.WrongEmailOrPassword);
                return;
            }
            // LoginUser
            await  LoginCustomerViewModel(userResult.Data);

        }
        private async Task<IActionResult> LoginCustomerViewModel(GetUserWithRoleDto loginDto )
        {
            // Create Claims
            var claims = new List<Claim>
            {
                new(ClaimTypes.Email, loginDto.Email),
                new(ClaimTypes.Name, (!string.IsNullOrWhiteSpace(loginDto.FullName) ? loginDto.FullName : loginDto.Email)),
            };
            foreach (var role in loginDto.Role)
            {
                claims.Add(new (ClaimTypes.Role,role));   
            }
            
            // Add Clams To ClaimIdentity
            var claimIdentity = new ClaimsIdentity(claims, Utility.AuthenticationScheme);
            // Create AuthConfiguration
            var authProperties = new AuthenticationProperties()
            {
                AllowRefresh = true,
                IsPersistent = LoginViewModel.IsRemeberMe,
                IssuedUtc = KalaMarket.Shared.Utility.Now,
            };
            // Try Signin
            await HttpContext.SignInAsync(Utility.AuthenticationScheme,
                new ClaimsPrincipal(claimIdentity), authProperties);
            return RedirectToPage("/");
        }

        #endregion /Methods

    }
}
