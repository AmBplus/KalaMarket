﻿using KalaMarket.Application.Services.Users.Queries.GetRole.Dto;

namespace KalaMarket.Application.Services.Users.Queries.GetRole.Interface;

public interface IGetRolesService
{
    ResultGetRolesDto Execute();
}