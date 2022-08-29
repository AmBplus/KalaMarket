using KalaMarket.Application.Services.Users.Queries.GetUsers.Dto;
using KalaMarket.Application.Services.Users.Queries.GetUsers.Interfaces;
using KalaMarket.EndPoint.Infrastructure;
namespace KalaMarket.EndPoint.Pages.Admin.Users
{
    public class IndexModel : BasePageModel
    {
        private IGetUsersService GetUsersService { get; }
        public ResultGetUserDto UsersInfo { get; set; }
        public IndexModel( IGetUsersService getUsersService)
        {
            GetUsersService = getUsersService;
        }
        public void OnGet(string? searchKey,int page = 1  )
        {
            UsersInfo = GetUsersService.Execute(new RequestGetUserDto()
            {
                Page = page,
                SearchKey = searchKey
            });
        }
    }
}
