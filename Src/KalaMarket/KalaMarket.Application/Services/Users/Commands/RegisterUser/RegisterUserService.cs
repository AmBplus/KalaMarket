using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Domain.Entities.UserAgg;
using KalaMarket.Resourses;
using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Services.Users.Commands.RegisterUser;

public class RegisterUserService : IRegisterUserService
{
    #region Properties_Fileds
    private IKalaMarketContext Context { get; }
    #endregion
   
    #region Ctor

    public RegisterUserService(IKalaMarketContext context)
    {
        Context = context;
    }

    #endregion Ctor
   
    #region Method

    /// <summary>
    /// Register User In Db
    /// </summary>
    /// <param name="registerUserDto"></param>
    /// <returns></returns>
    public ResultDto<ResultRegisterUserDto> Execute(RequestRegisterUserService registerUserDto)
    {
        // Create User
        User user = new User()
        {
            FullName = registerUserDto.FullName,
            Email = registerUserDto.Email,
        };
        List<UserInRole>  userInRole = new List<UserInRole>();
        // Add Role To New User
        foreach (var role in registerUserDto.Roles)
        {
            var roles = Context.Roles.Find(role.Id);
            userInRole.Add(new UserInRole()
            {
                User = user,
                RoleId = roles.Id,
                Role = roles,
                UserId = user.Id
            });
        }
        user.UserInRoles = userInRole;
        // Add User To Db
        Context.Users.Add(user);
        ResultDto<ResultRegisterUserDto> result = new ResultDto<ResultRegisterUserDto>();
        #region Try Save User And Return Result 

        try
        {
            if (Convert.ToBoolean(Context.SaveChanges()))
            {
                result.Data.UserId = user.Id;
                result.IsSuccess = true;
                result.Message = string.Format(Messages.RegisterSuccessMessageWithUserName, user.Email);
                return result;
            };
        }
        catch (Exception e)
        {
            result.Data.UserId = user.Id;
            result.IsSuccess = false;
            result.Message = string.Format(Messages.RegisterFailedMessageWithUserNameAndReason, user.Email,e.Message);
            return result;
        }
        result.Data.UserId = user.Id;
        result.IsSuccess = false;
        result.Message = string.Format(Messages.RegisterFailedMessageWithUserName, user.Email);
        return result;

        #endregion Try Save User And Return Result 
    }

    #endregion
}