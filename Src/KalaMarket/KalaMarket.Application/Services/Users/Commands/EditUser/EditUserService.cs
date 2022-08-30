using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Application.Services.Users.Commands.EditUser.Dto;
using KalaMarket.Resourses;
using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Services.Users.Commands.EditUser;

public class EditUserService : IEditUserService
{
    public EditUserService(IKalaMarketContext context)
    {
        Context = context;
    }

    private IKalaMarketContext Context { get; }
    public ResultDto Execute(EditUserDto editUser)
    {
        ResultDto result = new ResultDto();
        var user = Context.Users.FirstOrDefault(x => x.Id == editUser.id);
        if (user == null)
        {
            result.Message = Messages.NotFindUser;
            return result;
        }

        user.FullName = editUser.FullName;
        try
        {
            Context.SaveChanges();
            result.Message = Messages.OperationDoneSuccessfully;
            result.IsSuccess = true;
        }
        catch (Exception e)
        {
            result.Message = e.Message;
        }

        return result;
    }
}