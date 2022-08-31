using KalaMarket.Application.Services.Users.Queries.GetRole;
using KalaMarket.EndPoint.Models.Account.Customer;
using KalaMarket.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KalaMarket.EndPoint.Pages.Account
{
    public class RegisterModel : PageModel
    {
        public RegisterModel(IGetRoleService roleService)
        {
            RoleService = roleService;
        }

        private IGetRoleService RoleService { get; }
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

        public void OnPost()
        {
            if (!ModelState.IsValid) return;

        }
    }
}
