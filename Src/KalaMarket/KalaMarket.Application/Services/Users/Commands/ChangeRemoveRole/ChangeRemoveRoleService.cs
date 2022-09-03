using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Resourses;
using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Services.Users.Commands.ChangeRemoveRole;

public class ChangeRemoveRoleService : IChangeRemoveRoleService
{
    // Property
    public ChangeRemoveRoleService(IKalaMarketContext context)
    {
        Context = context;
    }
    // Ctor
    private IKalaMarketContext Context { get; }

    #region Method

    public ResultDto Execute(long id)
    {
        ResultDto resultDto = new ResultDto();
        var role = Context.Roles.FirstOrDefault(x => x.Id == id);
        if (role == null)
        {
            resultDto.Message = string.Format(Messages.NotFind,PropertiesName.Role);
            return resultDto;
        }

        role.ChangeIsRemoved();
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