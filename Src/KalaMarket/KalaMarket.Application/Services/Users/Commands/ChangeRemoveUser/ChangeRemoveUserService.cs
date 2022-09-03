using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Resourses;
using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Services.Users.Commands.ChangeRemoveUser;

public class ChangeRemoveUserService : IChangeRemoveUserService
{
    // Property
    public ChangeRemoveUserService(IKalaMarketContext context)
    {
        Context = context;
    }
    // Ctor
    private IKalaMarketContext Context { get; }

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
        user.ChangeIsRemoved();
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