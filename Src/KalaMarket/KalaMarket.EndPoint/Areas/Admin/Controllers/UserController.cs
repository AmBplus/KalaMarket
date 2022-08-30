using KalaMarket.Application.Services.Users.Commands.ChangeRemoveUser;
using KalaMarket.Shared.Dto;
using Microsoft.AspNetCore.Mvc;

namespace KalaMarket.EndPoint.Areas.Admin.Controllers;
[ApiController]
[Area("Admin")]
[Route("api/[area]/[controller]")]
public class UserController :ControllerBase
{
    public UserController(IChangeRemoveUserService changeRemoveUserService)
    {
        ChangeRemoveUserService = changeRemoveUserService;
    }
    [HttpGet]
    public IActionResult Get()
    {
        ResultDto result = new()
        {
            Message = "سلام",
            IsSuccess = true
        };
        return Ok(result);
    }
  
    private IChangeRemoveUserService ChangeRemoveUserService { get; }
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
}