﻿namespace KalaMarket.Application.User.Services.Users.Commands.RegisterUser.Dto;

public class RequestRegisterUserDto
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public long RoleId { get; set; }
}