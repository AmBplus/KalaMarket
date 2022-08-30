using KalaMarket.Application.Services.Users.Queries.GetUsers.Dto;
using KalaMarket.Application.Services.Users.Queries.GetUsers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KalaMarket.EndPoint.Pages.Admin.Users
{
    public class RemovedUsersModel : PageModel
    {
        public RemovedUsersModel(IGetRemovedUsersService removedUsersService)
        {
            RemovedUsersService = removedUsersService;
        }

        public ResultGetUserDto Users { get; set; }
        private IGetRemovedUsersService RemovedUsersService { get; }
        public void OnGet(int? page , string? searchKey)
        {
            if (page == null || page == 0) page = 1;  
            Users = RemovedUsersService.Execute(new RequestGetUserDto()
            {
                Page = page ,
                SearchKey = searchKey
            });
        }
    }
}
