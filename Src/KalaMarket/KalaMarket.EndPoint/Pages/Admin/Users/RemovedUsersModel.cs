using KalaMarket.Application.User.Services.Users.Commands.ChangeRemoveUser;
using KalaMarket.Application.User.Services.Users.Queries.GetUsers.Dto;
using KalaMarket.Application.User.Services.Users.Queries.GetUsers.Interfaces;
using KalaMarket.Resourses;
using KalaMarket.Shared.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KalaMarket.EndPoint.Pages.Admin.Users
{
    public class RemovedUsersModel : PageModel
    {
        public RemovedUsersModel(IGetRemovedUsersService removedUsersService, IChangeRemoveUserService changeRemoveUserService)
        {
            RemovedUsersService = removedUsersService;
            ChangeRemoveUserService = changeRemoveUserService;
        }

        public ResultGetUserDto Users { get; set; }
        private IGetRemovedUsersService RemovedUsersService { get; }
        IChangeRemoveUserService ChangeRemoveUserService { get;  }
        public void OnGet(int? page , string? searchKey)
        {
            if (page == null || page == 0) page = 1;  
            Users = RemovedUsersService.Execute(new RequestGetUserDto()
            {
                Page = page ,
                SearchKey = searchKey
            });
        }
        [HttpPut("{id?}")]
        public IActionResult OnPutChangeStatus(long? id)
        {
            if (id == null || id <= 0) return BadRequest(new ResultDto {Message = ErrorMessages.UnValidId});
            var result = ChangeRemoveUserService.Execute((long)id);
            if (!result.IsSuccess) return BadRequest(result);
            return new OkObjectResult(result);
        }
    }
}
