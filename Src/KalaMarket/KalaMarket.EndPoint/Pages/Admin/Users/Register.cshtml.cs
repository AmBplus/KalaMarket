using KalaMarket.Application.Services.Users.Commands.RegisterUser;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KalaMarket.EndPoint.Pages.Admin.Users
{
    public class RegisterModel : PageModel
    {
        #region Ctor

        public RegisterModel(IRegisterUserService registerUser)
        {
            RegisterUser = registerUser;
        }

        #endregion

        #region Properties_Fields

        public IRegisterUserService RegisterUser { get; }
        public RegisterUser Register { get; set; }

        #endregion Properties_Fields

        #region Methods

        public void OnGet()
        {
        }

        public void OnPost()
        {

        }

        #endregion Methods

    }

    public class RegisterUser 
    {

    }
}
