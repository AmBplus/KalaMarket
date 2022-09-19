using KalaMarket.Application.User.Services.Users.Commands.ChangeRemoveUser;
using KalaMarket.Application.User.Services.Users.Commands.EditUser;
using KalaMarket.Application.User.Services.Users.Commands.EditUser.Dto;
using Microsoft.AspNetCore.Mvc;

namespace KalaMarket.EndPoint.Areas.Admin.Controllers;
[ApiController]
[Area("Admin")]
[Route("api/[area]/[controller]")]
public class UserController :ControllerBase
{
    public UserController(IChangeRemoveUserService changeRemoveUserService, IEditUserService editUserService)
    {
        ChangeRemoveUserService = changeRemoveUserService;
        EditUserService = editUserService;
    }

  
    private IChangeRemoveUserService ChangeRemoveUserService { get; }
    private IEditUserService EditUserService { get; }
    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        var result = ChangeRemoveUserService.Execute(id);
        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }
        return Ok(result);
    }

    [HttpPut]
    public IActionResult Put(EditUserDto editUserDto)
    {
        var result = EditUserService.Execute(editUserDto);
        if (!result.IsSuccess) return BadRequest(result);
        return Ok(result);
    }
}