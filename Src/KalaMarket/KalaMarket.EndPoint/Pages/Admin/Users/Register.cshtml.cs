using KalaMarket.Application.Services.Users.Commands.RegisterUser;
using KalaMarket.Application.Services.Users.Queries.GetRole;
using KalaMarket.Application.Services.Users.Queries.GetUsers;
using KalaMarket.EndPoint.Infrastructure;
using KalaMarket.EndPoint.Models.Admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KalaMarket.EndPoint.Pages.Admin.Users
{
    public class RegisterModel : BasePageModel
    {
        #region Ctor

        public RegisterModel(IRegisterUserService registerUser, IGetRolesService rolesService)
        {
            RegisterUser = registerUser;
            RolesService = rolesService;
        }

        #endregion

        #region Properties_Fields

        public IRegisterUserService RegisterUser { get; }
        public IGetRolesService RolesService{ get; }
        [BindProperty]
        public RegisterViewModel Register { get; set; }
        public SelectList Roles { get; set; }
        #endregion Properties_Fields

        #region Methods

        public void OnGet()
        {
            AddToastError("error1");
            AddToastError("error2");
            AddToastError("error3");
            AddToastSuccess("Success0");
            AddToastSuccess("Success1");
            AddToastSuccess("Success2");
            AddToastSuccess("Success3");
            AddToastInformation("سلام بر تو دوست عزیز");
            AddToastInformation("سلام بر تو دوست عزیز1");
            AddToastInformation("سلام بر تو دوست عزیز2");
            AddToastWarning("Warning1");
            AddToastWarning("Warning2");
            AddToastWarning("Warning3");
            Roles = new SelectList(RolesService.Execute().Roles, "Id", "Name");
        }

        public void OnPost()
        {
       
            
            if (!ModelState.IsValid)
            {
                Roles = new SelectList(RolesService.Execute().Roles, "Id", "Name");
                return;
            }


        }

        #endregion Methods
        
    }
}
