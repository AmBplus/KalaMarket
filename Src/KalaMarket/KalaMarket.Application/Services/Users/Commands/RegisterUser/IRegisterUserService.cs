using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Services.Users.Commands.RegisterUser;

public interface IRegisterUserService
{
    ResultDto<ResultRegisterUserDto> Execute(RequestRegisterUserService registerUserDto);
}