﻿using KalaMarket.Application.User.Services.Users.Queries.Dto;

namespace KalaMarket.Application.User.Services.Users.Queries.GetRoles.Interface;

public interface IGetRolesService
{
    ResultGetRolesDto Execute();
}