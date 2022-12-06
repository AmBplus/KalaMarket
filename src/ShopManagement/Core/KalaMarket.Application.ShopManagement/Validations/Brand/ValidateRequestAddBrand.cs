using FluentValidation;
using KalaMarket.Application.ShopManagement.Services.ProductAgg.BrandService.Command.Add;
using KalaMarket.Resourses;
using KalaMarket.Shared;

namespace KalaMarket.Application.ShopManagement.Validations.Brand;

public class ValidateRequestAddBrand : AbstractValidator<RequestAddBrand>
{
    public ValidateRequestAddBrand()
    {
        RuleFor(x => x.Name).NotNull().WithMessage(x => ErrorFluentValidation.Null)
            .NotEmpty().WithMessage(ErrorFluentValidation.EmptyOrWhiteSpace)
            .MaximumLength(KalaMarketConstants.MaxLength.Name).WithMessage(ErrorFluentValidation.MaxLen);
    }
}