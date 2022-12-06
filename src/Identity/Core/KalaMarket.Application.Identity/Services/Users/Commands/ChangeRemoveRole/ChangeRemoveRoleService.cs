using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Resourses;
using KalaMarket.Shared;
using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Identity.Services.Users.Commands.ChangeRemoveRole;

public class ChangeRemoveRoleService : IChangeRemoveRoleService
{
    // Ctor
    public ChangeRemoveRoleService(IKalaMarketContext context, ILoggerManger logManger)
    {
        Context = context;
        LogManger = logManger;
    }

    #region Method

    public ResultDto Execute(long id)
    {
        var resultDto = new ResultDto();
        var role = Context.Roles.FirstOrDefault(x => x.Id == id);
        if (role == null)
        {
            resultDto.Message = string.Format(Messages.NotFind, PropertiesName.Role);
            LogManger.LogInformation(string.Format(Messages.NotFind, PropertiesName.Role));
            return resultDto;
        }

        // Change Role Remove Status
        role.ChangeRemoveStatus();
        try
        {
            Context.SaveChanges();
            resultDto.IsSuccess = true;
            resultDto.Message = Messages.OperationDoneSuccessfully;
            LogManger.LogInformation(Messages.OperationDoneSuccessfully);
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

    private IKalaMarketContext Context { get; }
    private ILoggerManger LogManger { get; }

    #endregion /Properties
}