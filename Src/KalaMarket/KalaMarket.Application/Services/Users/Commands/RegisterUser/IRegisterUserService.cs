using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Services.Users.Commands.RegisterUser;

public interface IRegisterUserService
{
    ResultListMessageDto<ResultRegisterUserDto> Execute(RequestRegisterUserDto registerUserDto);
}