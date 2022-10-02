using KalaMarket.Application.User.Services.Users.Commands.RegisterUser.Dto;
using KalaMarket.Application.User.Services.Users.FacadePattern;
using KalaMarket.EndPoint.Infrastructure;
using KalaMarket.EndPoint.Models.Account.Admin;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KalaMarket.EndPoint.Pages.Admin.Users
{
    public class RegisterModel : BasePageModel
    {
        #region Ctor

        public RegisterModel(IUserAggFacadeService userAggFacadeService)
        {
            UserAggFacadeService = userAggFacadeService;
        }

        #endregion

        #region Properties_Fields

        private IUserAggFacadeService UserAggFacadeService { get; }

        [BindProperty]
        public RegisterAdminViewModel RegisterAdmin { get; set; }
        public SelectList Roles { get; set; }
        #endregion Properties_Fields

        #region Methods

        public void OnGet()
        {
            Roles = new SelectList(UserAggFacadeService.UserQuery.GetRolesService.Execute().Roles, "Id", "Name");
        }

        public IActionResult OnPost()
        {
            // Check Model Is Valid
            if (!ModelState.IsValid)
            {
                Roles = new SelectList(UserAggFacadeService.UserQuery.GetRolesService.Execute().Roles, "Id", "Name");
                return Page();
            }

            // Register User
            var result = UserAggFacadeService.UserCommand.RegisterUserService.Execute(RegisterAdmin.Adapt<RequestRegisterUserDto>());
            // Check Register Is Failed
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                AddToastError(result.Message);
                return Page();
            }
            // Register Successfully Done Reload Page
            AddToastSuccess(result.Message);
            return RedirectToPage();
        }

        #endregion Methods

    }
}
