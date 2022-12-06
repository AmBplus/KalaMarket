using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Resourses;
using KalaMarket.Shared;
using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Identity.Services.Users.Commands.ChangeActivationUser;

public class ChangeActivationUserService : IChangeActivationUserService
{
    #region Ctor

    public ChangeActivationUserService(IKalaMarketContext context, ILoggerManger logManger)
    {
        LogManger = logManger;
        Context = context;
    }

    #endregion

    #region Method

    public ResultDto Execute(long id)
    {
        var resultDto = new ResultDto();
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
            LogManger.LogError(e, e.Message);
        }

        return resultDto;
    }

    #endregion /Method

    #region Properties

    // Property
    private ILoggerManger LogManger { get; }
    private IKalaMarketContext Context { get; }

    #endregion
}