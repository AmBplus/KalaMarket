﻿using KalaMarket.Application.Identity.Services.Users.Commands.EditUser.Dto;
using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Resourses;
using KalaMarket.Shared;
using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Identity.Services.Users.Commands.EditUser;

public class EditUserService : IEditUserService
{
    public EditUserService(IKalaMarketContext context, ILoggerManger loggerManger)
    {
        Context = context;
        LoggerManger = loggerManger;
    }

    private ILoggerManger LoggerManger { get; }
    private IKalaMarketContext Context { get; }

    public ResultDto Execute(EditUserDto editUser)
    {
        var result = new ResultDto();
        var user = Context.Users.FirstOrDefault(x => x.Id == editUser.id);
        if (user == null)
        {
            result.Message = Messages.NotFindUser;
            LoggerManger.LogInformation(Messages.NotFindUser);
            return result;
        }

        user.Update(editUser.FullName);
        try
        {
            Context.SaveChanges();
            result.Message = Messages.OperationDoneSuccessfully;
            LoggerManger.LogInformation(Messages.OperationDoneSuccessfully);
            result.IsSuccess = true;
        }
        catch (Exception e)
        {
            result.Message = e.Message;
            LoggerManger.LogError(e, e.Message);
        }

        return result;
    }
}