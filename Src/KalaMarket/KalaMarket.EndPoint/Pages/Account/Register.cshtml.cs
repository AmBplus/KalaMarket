using System.Security.Claims;
using KalaMarket.Application.Services.Users.Commands.RegisterUser.Dto;
using KalaMarket.Application.Services.Users.Commands.RegisterUser.Interfaces;
using KalaMarket.Application.Services.Users.Queries.GetRole;
using KalaMarket.EndPoint.Infrastructure;
using KalaMarket.EndPoint.Models.Account.Customer;
using KalaMarket.Shared;
using Mapster;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace KalaMarket.EndPoint.Pages.Account
{
    public class RegisterModel : BasePageModel
    {
        public RegisterModel(IGetRoleService roleService , IRegisterUserService registerUserService)
        {
            RoleService = roleService;
            RegisterUserService = registerUserService;
        }

        private IGetRoleService RoleService { get; }
        private IRegisterUserService RegisterUserService { get; }
        [BindProperty]
        public RegisterCustomerViewModel RegisterUser { get; set; } 
        public void OnGet()
        {
            var roleId =RoleService.Execute(UserRoles.Customer.ToString());
            if (roleId == null)
            {
                throw new Exception("با پشتبانی تماس حاصل فرمایید");
            }

            RegisterUser = new();
            RegisterUser.RoleId = (long)roleId;
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();
            var result = RegisterUserService.Execute(RegisterUser.Adapt<RequestRegisterUserDto>());

            if (result.IsSuccess)
            {
                AddToastSuccess(result.Message); 
                await LoginUser(RegisterUser);
                return RedirectToPage("/");
            }
            else
            {
                AddToastError(result.Message);
                ModelState.AddModelError("",result.Message);
                return Page();
            }

        }

        private async Task LoginUser(RegisterCustomerViewModel registerUser)
        {
            if (User != null || User.Identity != null || User.Identity.IsAuthenticated ||  User.Identities.Count() > 0)
            {
                await HttpContext.SignOutAsync(Infrastructure.Security.Utility.AuthenticationScheme);
            }
            var claims = new List<Claim>()
            {
                new(ClaimTypes.Email, registerUser.Email),
                new(ClaimTypes.Name, registerUser.Email),
                new(ClaimTypes.Role, UserRoles.Customer.ToString())
            };
            var claimIdentity = new ClaimsIdentity(claims, Infrastructure.Security.Utility.AuthenticationScheme);
            var authProperties = new AuthenticationProperties()
            {
                AllowRefresh = true,
                IsPersistent = false,
                IssuedUtc = Utility.Now,
            };
            await HttpContext.SignInAsync(Infrastructure.Security.Utility.AuthenticationScheme,
                new ClaimsPrincipal(claimIdentity), authProperties);
            
        }
    }
}
