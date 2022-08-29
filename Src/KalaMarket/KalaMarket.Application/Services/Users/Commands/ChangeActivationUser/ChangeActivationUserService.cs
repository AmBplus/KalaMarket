using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Application.Services.Users.Commands.ChangeRemoveRole;
using KalaMarket.Resourses;
using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Services.Users.Commands.ChangeActivationUser;

public class ChangeActivationUserService : IChangeActivationUserService
{
    #region Ctor

    // Ctor
    public ChangeActivationUserService(IKalaMarketContext context)
    {
        Context = context;
    }

    #endregion

    #region Property

    // Property
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
            return resultDto;
        }
        user.IsActive = !user.IsActive;
        try
        {
            Context.SaveChanges();
            resultDto.IsSuccess = true;
            resultDto.Message = Messages.OperationDoneSuccessfully;
        }
        catch (Exception e)
        {
            resultDto.Message = e.Message;
        }

        return resultDto;
    }

    #endregion /Method
}