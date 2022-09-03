using FluentValidation;
using KalaMarket.Application.Services.Users.Commands.RegisterUser.Dto;
using KalaMarket.Resourses;
using KalaMarket.Shared;

namespace KalaMarket.Application.Validations.User;

public class RegisterUserValidator : AbstractValidator<RequestRegisterUserDto>
{
    public RegisterUserValidator()
    {
        // FullName
        RuleFor(x => x.FullName)
            .MaximumLength(KalaMarketConstants.MaxLength.FullName)
            .WithMessage(x => ErrorFluentValidation.MaxLen)
            .NotNull().WithMessage(x => ErrorFluentValidation.Null)
            .NotEmpty().WithMessage(x => ErrorFluentValidation.EmptyOrWhiteSpace);
        // EmailAddress
        RuleFor(x => x.Email).EmailAddress().WithMessage(x => ErrorFluentValidation.EmailType);
        // Password 
        //RuleFor(x => x.Password)
        //    .MinimumLength(KalaMarketConstants.MinLength.Password).WithMessage(x => ErrorFluentValidation.MinLen)
        //    .MaximumLength(KalaMarketConstants.MaxLength.Password).WithMessage(x => ErrorFluentValidation.MaxLen);

    }
}