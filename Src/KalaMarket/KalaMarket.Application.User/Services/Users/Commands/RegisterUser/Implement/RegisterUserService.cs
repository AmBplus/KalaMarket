using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Application.User.Services.Users.Commands.RegisterUser.Dto;
using KalaMarket.Application.User.Services.Users.Commands.RegisterUser.Interfaces;
using KalaMarket.Application.User.Validations.User;
using KalaMarket.Application.User.Validations.Utility;
using KalaMarket.Domain.Entities.UserAgg;
using KalaMarket.Resourses;
using KalaMarket.Shared;
using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.User.Services.Users.Commands.RegisterUser.Implement;

public class RegisterUserService : IRegisterUserService
{
    #region Properties_Fileds
    private IKalaMarketContext Context { get; }
    private ILoggerManger LoggerManger { get; }
    #endregion

    #region Ctor

    public RegisterUserService(IKalaMarketContext context, ILoggerManger loggerManger)
    {
        Context = context;
        LoggerManger = loggerManger;
    }

    #endregion Ctor

    #region Method

    /// <summary>
    /// Register User In Db
    /// </summary>
    /// <param name="registerUserDto"></param>
    /// <returns></returns>
    public ResultDto<ResultRegisterUserDto> Execute(RequestRegisterUserDto registerUserDto)
    {
        ResultDto<ResultRegisterUserDto> result = new (new ResultRegisterUserDto());

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
                result.Message =(string.Format(Messages.RegisterSuccessMessageWithUserName, user.Email));
                LoggerManger.LogInformation(Messages.RegisterSuccessMessageWithUserName, user.Email);
            }
        }
        catch (Exception e)
        {
            result.Data.UserId = user.Id;
            result.IsSuccess = false;
            result.Message = string.Format(Messages.RegisterFailedMessageWithUserName,registerUserDto.Email);
            LoggerManger.LogError(exception: e, message: e.Message);
        } 
        return result;

        #endregion Try Save User And Return Result 
    }

    private Domain.Entities.UserAgg.User CreateUser(RequestRegisterUserDto registerUserDto)
    {
        return  new Domain.Entities.UserAgg.User(fullName:registerUserDto.FullName,email:registerUserDto.Email,password:registerUserDto.Password);
    }

    private bool ValidateRequestRegisterDto(RequestRegisterUserDto registerUserDto, ResultDto<ResultRegisterUserDto> result)
    {
        RegisterUserValidator userValidator = new RegisterUserValidator();
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

    private bool AddUserInRole(Domain.Entities.UserAgg.User user, long roleId)
    {
        var roles = Context.Roles.Find(roleId);
        if (roles != null)
        {
            // Add Role To New User
            UserInRole userInRole = new UserInRole()
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