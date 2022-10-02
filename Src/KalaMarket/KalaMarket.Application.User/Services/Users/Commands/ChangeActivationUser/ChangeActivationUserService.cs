
using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Resourses;
using KalaMarket.Shared;
using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.User.Services.Users.Commands.ChangeActivationUser;

public class ChangeActivationUserService : IChangeActivationUserService
{
    #region Ctor
    public ChangeActivationUserService(IKalaMarketContext context, ILoggerManger logManger)
    {
        LogManger = logManger;
        Context = context;
    }
    #endregion

    #region Properties

    // Property
    private ILoggerManger LogManger { get; set; }
    private IKalaMarketContext Context { get; }
    #endregion

    #region Method

    public ResultDto Execute(long id)
    {
        ResultDto resultDto = new ResultDto();
        var user = Context.Users.FirstOrDefault(x => x.Id == id);
        if (user == null)
        {
            resultDto.Message = Messages.NotFindUser;
            LogManger.LogInformation(Messages.NotFindUser);
            return resultDto;
        }

        user.ChangeActivation();
        try
        {
            Context.SaveChanges();
            resultDto.IsSuccess = true;
            LogManger.LogInformation(Messages.OperationDoneSuccessfully);
            resultDto.Message = Messages.OperationDoneSuccessfully;
        }
        catch (Exception e)
        {
            resultDto.Message = e.Message;
            LogManger.LogError(exception: e, message: e.Message);
        }

        return resultDto;
    }

    #endregion /Method
}