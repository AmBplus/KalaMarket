using KalaMarket.Application.Services.Users.Commands.RegisterUser.Dto;
using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Services.Users.Commands.RegisterUser.Interfaces;

public interface IRegisterUserService
{
    ResultDto<ResultRegisterUserDto> Execute(RequestRegisterUserDto registerUserDto);
}