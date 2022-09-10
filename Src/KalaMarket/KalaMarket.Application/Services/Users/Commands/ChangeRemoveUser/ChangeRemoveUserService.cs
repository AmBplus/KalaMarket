using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Resourses;
using KalaMarket.Shared;
using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Services.Users.Commands.ChangeRemoveUser;

public class ChangeRemoveUserService : IChangeRemoveUserService
{
    // Property
    public ChangeRemoveUserService(IKalaMarketContext context, ILoggerManger loggerManger)
    {
        Context = context;
        LoggerManger = loggerManger;
    }
    // Ctor
    private IKalaMarketContext Context { get; }
    private ILoggerManger LoggerManger { get; }

    #region Method

    public ResultDto Execute(long id)
    {
        ResultDto resultDto = new ResultDto();
        var user = Context.Users.FirstOrDefault(x => x.Id == id);
        if (user == null)
        {
            LoggerManger.LogInformation(message: Messages.NotFindUser);
            resultDto.Message = Messages.NotFindUser;
            return resultDto;
        }
        user.ChangeRemoveStatus();
        try
        {
            Context.SaveChanges();
            resultDto.IsSuccess = true;
            resultDto.Message = Messages.OperationDoneSuccessfully;
            LoggerManger.LogInformation(message: Messages.OperationDoneSuccessfully);
        }
        catch (Exception e)
        {
            resultDto.Message = e.Message;
            LoggerManger.LogError(exception: e, message: e.Message);
        }

        return resultDto;
    }

    #endregion /Method
}