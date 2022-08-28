using FluentValidation;
using KalaMarket.Application.Services.Users.Commands.RegisterUser;
using KalaMarket.Resourses;
using KalaMarket.Shared;

namespace KalaMarket.Application.Validations;

public class RegisterUserValidator : AbstractValidator<RequestRegisterUserDto>
{
    public RegisterUserValidator()
    {
        // FullName
        RuleFor(x => x.FullName)
            .MaximumLength(Shared.KalaMarketConstants.MaxLength.FullName)
            .WithMessage(x => KalaMarket.Resourses.ErrorFluentValidation.MaxLen)
            .NotNull().WithMessage(x => Resourses.ErrorFluentValidation.Null)
            .NotEmpty().WithMessage(x => Resourses.ErrorFluentValidation.EmptyOrWhiteSpace);
        // EmailAddress
        RuleFor(x => x.Email).EmailAddress().WithMessage(x => ErrorFluentValidation.EmailType);
        // Password 
        //RuleFor(x => x.Password)
        //    .MinimumLength(KalaMarketConstants.MinLength.Password).WithMessage(x => ErrorFluentValidation.MinLen)
        //    .MaximumLength(KalaMarketConstants.MaxLength.Password).WithMessage(x => ErrorFluentValidation.MaxLen);

    }
}