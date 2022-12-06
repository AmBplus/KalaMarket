using KalaMarket.Application.Identity.Services.Users.Commands.RegisterUser.Dto;
using KalaMarket.Application.Identity.Services.Users.Commands.RegisterUser.Interfaces;
using KalaMarket.Application.Identity.Validations.User;
using KalaMarket.Application.Identity.Validations.Utility;
using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Domain.Identity.UserAgg;
using KalaMarket.Resourses;
using KalaMarket.Shared;
using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Identity.Services.Users.Commands.RegisterUser.Implement;

public class RegisterUserService : IRegisterUserService
{
    #region Ctor

    public RegisterUserService(IKalaMarketContext context, ILoggerManger loggerManger)
    {
        Context = context;
        LoggerManger = loggerManger;
    }

    #endregion Ctor

    #region Properties_Fileds

    private IKalaMarketContext Context { get; }
    private ILoggerManger LoggerManger { get; }

    #endregion

    #region Method

    /// <summary>
    ///     Register User In Db
    /// </summary>
    /// <param name="registerUserDto"></param>
    /// <returns></returns>
    public ResultDto<ResultRegisterUserDto> Execute(RequestRegisterUserDto registerUserDto)
    {
        ResultDto<ResultRegisterUserDto> result = new(new ResultRegisterUserDto());

        //*******
        if (ValidateRequestRegisterDto(registerUserDto, result)) return result;
        //******
        if (CheckEmailExits(registerUserDto.Email, result)) return result;
        // Create User
        var user = CreateUser(registerUserDto);
        //******
        AddUserInRole(user, registerUserDto.RoleId);
        //******
        Context.Users.Add(user);

        #region Try Save User And Return Result

        try
        {
            if (Convert.ToBoolean(Context.SaveChanges()))
            {
                result.Data.UserId = user.Id;
                result.IsSuccess = true;
                result.Message = string.Format(Messages.RegisterSuccessMessageWithUserName, user.Email);
                LoggerManger.LogInformation(Messages.RegisterSuccessMessageWithUserName, user.Email);
            }
        }
        catch (Exception e)
        {
            result.Data.UserId = user.Id;
            result.IsSuccess = false;
            result.Message = string.Format(Messages.RegisterFailedMessageWithUserName, registerUserDto.Email);
            LoggerManger.LogError(e, e.Message);
        }

        return result;

        #endregion Try Save User And Return Result
    }

    private User CreateUser(RequestRegisterUserDto registerUserDto)
    {
        return new User(registerUserDto.FullName, registerUserDto.Email,
            registerUserDto.Password);
    }

    private bool ValidateRequestRegisterDto(RequestRegisterUserDto registerUserDto,
        ResultDto<ResultRegisterUserDto> result)
    {
        var userValidator = new RegisterUserValidator();
        var resultValidate = userValidator.Validate(registerUserDto);
        if (resultValidate.Errors.Count > 0)
        {
            result.IsSuccess = false;
            result.Message = resultValidate.Errors.ToStringError();
            return true;
        }

        return false;
    }

    private bool CheckEmailExits(string email, ResultDto<ResultRegisterUserDto> result)
    {
        var emailExitsInDb = Context.Users.FirstOrDefault(x => x.Email.ToLower() == email.ToLower());
        if (emailExitsInDb != null)
        {
            result.Message = ErrorMessages.EmailExists;
            return true;
        }

        return false;
    }

    private bool AddUserInRole(User user, long roleId)
    {
        var roles = Context.Roles.Find(roleId);
        if (roles != null)
        {
            // Add Role To New User
            var userInRole = new UserInRole
            {
                User = user,
                RoleId = roles.Id,
                Role = roles,
                UserId = user.Id
            };
            user.UserInRoles.Add(userInRole);
            return true;
        }

        return false;
    }

    #endregion
}