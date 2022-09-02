using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Application.Services.Users.Queries.GetUsers.Dto;
using KalaMarket.Application.Services.Users.Queries.GetUsers.Interfaces;
using KalaMarket.Resourses;
using KalaMarket.Shared.Dto;
using KalaMarket.Shared.Security;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace KalaMarket.Application.Services.Users.Queries.GetUsers.Implement;

public class GetUserWithRolesService : IGetUserWithRolesService
{
    public GetUserWithRolesService(IKalaMarketContext context)
    {
        Context = context;
    }

    
    private IKalaMarketContext Context { get; }
    public ResultDto<GetUserWithRoleDto> Execute(RequestGetUserWithRolesDto request)
    {
        var user = Context.Users.Include(x => x.UserInRoles).ThenInclude(x => x.Role).Select(x =>new GetUserWithRoleDto()
        {
            Email = x.Email,
            FullName = x.FullName,
            Password = x.Password,
            Id = x.Id,
            Role = x.UserInRoles.Select(x=>x.Role.Name)
        }).Where(x => x.Email == request.Email).FirstOrDefault();
        ResultDto<GetUserWithRoleDto> result = new ResultDto<GetUserWithRoleDto>(user);
        if (user == null)
        {
            result.Message = Messages.NotFindUser;
            return result;
        }
       
            result.Message = Messages.OperationDoneSuccessfully;
            result.IsSuccess = true;
            return result;
    }
}