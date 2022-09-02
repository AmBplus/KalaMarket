using KalaMarket.Application.Services.Users.Queries.GetUsers.Dto;
using KalaMarket.Resourses;
using KalaMarket.Shared.Dto;
using Task = System.Threading.Tasks.Task;
using KalaMarket.Application.Services.Users.Queries.GetUsers.Interfaces;
using KalaMarket.EndPoint.Infrastructure;
using KalaMarket.EndPoint.Models.Account.Customer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KalaMarket.Shared;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace KalaMarket.EndPoint.Pages.Account
{
    public class LoginModel : BasePageModel
    {
        public LoginModel(IGetUserWithRolesService userService)
        {
            UserService = userService;
        }

        [BindProperty]
        public LoginCustomerViewModel LoginViewModel { get; set; }
        private IGetUserWithRolesService UserService { get; }
        public void OnGet()
        {
        }

        public async Task OnPost()
        {
            if(!ModelState.IsValid)return;
           var userResult =  UserService.Execute(new RequestGetUserWithRolesDto()
            {
                Email = LoginViewModel.Email,
                Password = LoginViewModel.Password
            });
           if (!userResult.IsSuccess)
           {
               ModelState.AddModelError("", userResult.Message);
               AddToastError(userResult.Message);
               return;
           }

           var isSamePassword = string.Compare(LoginViewModel.Password, userResult.Data.Password,ignoreCase: false);
           if (isSamePassword == 0)
           {
               ModelState.AddModelError("", errorMessage:ErrorMessages.WrongEmailOrPassword);
               AddToastError(ErrorMessages.WrongEmailOrPassword);
               return;
            }

            await  LoginCustomerViewModel(userResult.Data);

        }
        private async Task<IActionResult> LoginCustomerViewModel(GetUserWithRoleDto loginDto )
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.Email, loginDto.Email),
                new(ClaimTypes.Name, (!string.IsNullOrWhiteSpace(loginDto.FullName) ? loginDto.FullName : loginDto.Email)),
            };
            foreach (var role in loginDto.Role)
            {
             claims.Add(new (ClaimTypes.Role,role));   
            }

            var claimIdentity = new ClaimsIdentity(claims, Infrastructure.Security.Utility.AuthenticationScheme);
            var authProperties = new AuthenticationProperties()
            {
                AllowRefresh = true,
                IsPersistent = LoginViewModel.IsRemeberMe,
                IssuedUtc = Utility.Now,
            };
            await HttpContext.SignInAsync(Infrastructure.Security.Utility.AuthenticationScheme,
                new ClaimsPrincipal(claimIdentity), authProperties);
            return RedirectToPage("/");
        }

    }
}
