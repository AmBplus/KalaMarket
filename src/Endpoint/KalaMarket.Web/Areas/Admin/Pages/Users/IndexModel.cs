using KalaMarket.Application.Identity.Services.Users.Commands.ChangeActivationUser;
using KalaMarket.Application.Identity.Services.Users.Queries.GetUsers.Dto;
using KalaMarket.Application.Identity.Services.Users.Queries.GetUsers.Interfaces;
using KalaMarket.Resourses;
using Microsoft.AspNetCore.Mvc;
using Shared.AspNetCore.Infrastructure;

namespace KalaMarket.Web.Areas.Admin.Pages.Users;

public class IndexModel : BasePageModel
{
    public IndexModel(IGetUsersService getUsersService, IChangeActivationUserService changeActivationUser)
    {
        GetUsersService = getUsersService;
        ChangeActivationUser = changeActivationUser;
    }

    private IGetUsersService GetUsersService { get; }
    private IChangeActivationUserService ChangeActivationUser { get; }
    public ResultGetUserDto UsersInfo { get; set; }

    public void OnGet(string? searchKey, int page = 1)
    {
        UsersInfo = GetUsersService.Execute(new RequestGetUserDto
        {
            Page = page,
            SearchKey = searchKey
        });
    }

    [HttpPut("{id?}")]
    public IActionResult OnPutChangeUserActivation(long? id)
    {
        if (id == null || id <= 0) return BadRequest(ErrorMessages.UnValidId);
        var result = ChangeActivationUser.Execute((long)id);
        if (result.IsSuccess) return new OkObjectResult(result);
        return BadRequest(result);
    }
}