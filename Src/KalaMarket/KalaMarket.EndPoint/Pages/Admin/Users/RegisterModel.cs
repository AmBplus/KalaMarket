using KalaMarket.Application.User.Services.Users.Commands.RegisterUser.Dto;
using KalaMarket.Application.User.Services.Users.FacadePattern;
using KalaMarket.EndPoint.Infrastructure;
using KalaMarket.EndPoint.Models.Account.Admin;
using KalaMarket.Shared.Dto;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KalaMarket.EndPoint.Pages.Admin.Users
{
    public class RegisterModel : BasePageModel
    {
        #region Ctor

        public RegisterModel(IUserFacadeService userFacadeService)
        {
            UserFacadeService = userFacadeService;
        }

        #endregion

        #region Properties_Fields

        private IUserFacadeService UserFacadeService { get; } 
     
        [BindProperty]
        public RegisterAdminViewModel RegisterAdmin { get; set; }
        public SelectList Roles { get; set; }
        #endregion Properties_Fields

        #region Methods

        public void OnGet()
        {
            Roles = new SelectList(UserFacadeService.UserQuery.GetRolesService.Execute().Roles, "Id", "Name");
        }

        public IActionResult OnPost()
        {
            // Check Model Is Valid
            if (!ModelState.IsValid)
            {
                Roles = new SelectList(UserFacadeService.UserQuery.GetRolesService.Execute().Roles, "Id", "Name");
                return Page();
            }
            
            // Register User
            var result =UserFacadeService.UserCommand.RegisterUserService.Execute(RegisterAdmin.Adapt<RequestRegisterUserDto>());
            // Check Register Is Failed
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("",result.Message);
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
