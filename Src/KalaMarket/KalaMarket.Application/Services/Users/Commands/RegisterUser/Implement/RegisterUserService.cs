using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Application.Services.Users.Commands.RegisterUser.Dto;
using KalaMarket.Application.Services.Users.Commands.RegisterUser.Interfaces;
using KalaMarket.Application.Validations;
using KalaMarket.Domain.Entities.UserAgg;
using KalaMarket.Resourses;
using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Services.Users.Commands.RegisterUser.Implement;

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
    public ResultListMessageDto<ResultRegisterUserDto> Execute(RequestRegisterUserDto registerUserDto)
    {
        ResultListMessageDto<ResultRegisterUserDto> result = new ResultListMessageDto<ResultRegisterUserDto>();
        IList<string> errorsList = new List<string>();
        RegisterUserValidator userValidator = new RegisterUserValidator();
        var resultValidate = userValidator.Validate(registerUserDto);
        if (resultValidate.Errors.Count > 0)
        {

            foreach (var error in resultValidate.Errors)
            {
                errorsList.Add(error.ErrorMessage);
            }

            result.IsSuccess = false;
            result.Messages = errorsList;
            return result;
        }
        // Create User
        User user = new User()
        {
            FullName = registerUserDto.FullName,
            Email = registerUserDto.Email,
        };
        List<UserInRole> userInRole = new List<UserInRole>();
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

        #region Try Save User And Return Result

        try
        {
            if (Convert.ToBoolean(Context.SaveChanges()))
            {
                result.Data.UserId = user.Id;
                result.IsSuccess = true;
                errorsList.Add(string.Format(Messages.RegisterSuccessMessageWithUserName, user.Email));

            }
        }
        catch (Exception e)
        {
            result.Data.UserId = user.Id;
            result.IsSuccess = false;
            errorsList.Add(string.Format(Messages.RegisterFailedMessageWithUserNameAndReason, user.Email, e.Message));
        }
        finally
        {
            result.Messages = errorsList;
        }
        return result;

        #endregion Try Save User And Return Result 
    }

    #endregion
}