using KalaMarket.Application.Services.Users.Commands.RegisterUser.Dto;
using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Services.Users.Commands.RegisterUser.Interfaces;

public interface IRegisterUserService
{
    ResultListMessageDto<ResultRegisterUserDto> Execute(RequestRegisterUserDto registerUserDto);
}