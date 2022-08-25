using System.Xml;
using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Domain.Entities.UserAgg;
using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Services.Users.Commands.RegisterUser;

public class RegisterUserService : IRegisterUserService
{
    private IKalaMarketContext Context { get; }
    public ResultDto<ResultRegisterUserDto> Execute(RequestRegisterUserService registerUserDto)
    {
        Context.Users.Add(new User()
        {
            FullName = registerUserDto.FullName,
            Email = registerUserDto.Email,
        });
        foreach (var role in registerUserDto.Roles)
        {
            var roles = Context.Roles.Find(role.Id);
             
        }
        throw new NotImplementedException();
    }
}