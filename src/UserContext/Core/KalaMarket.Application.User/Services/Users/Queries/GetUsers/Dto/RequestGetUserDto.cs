﻿namespace KalaMarket.Application.User.Services.Users.Queries.GetUsers.Dto;

public class RequestGetUserDto
{
    public string? SearchKey { get; set; }
    public int? Page { get; set; } = 1;
}