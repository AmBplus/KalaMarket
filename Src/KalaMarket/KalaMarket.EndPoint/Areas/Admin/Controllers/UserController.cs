using KalaMarket.Application.Services.Users.Commands.ChangeRemoveUser;
using Microsoft.AspNetCore.Mvc;

namespace KalaMarket.EndPoint.Areas.Admin.Controllers;

[Area("Admin")]
[Route("api/[controller]")]
public class UserController :ControllerBase
{
    public UserController(IChangeRemoveUserService changeRemoveUserService)
    {
        ChangeRemoveUserService = changeRemoveUserService;
    }

    private IChangeRemoveUserService ChangeRemoveUserService { get; }
    [HttpDelete]
    public IActionResult Delete(long id)
    {
        var result = ChangeRemoveUserService.Execute(id);
        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }
        return Ok(result);
    }
}