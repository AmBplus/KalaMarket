using FluentValidation;
using KalaMarket.Application.Product.Services.Product.CategoryServices.Commands.EditCategory;
using KalaMarket.Resourses;

namespace KalaMarket.Application.Product.Validations.Category;

public class EditCategoryDtoValidation : AbstractValidator<RequestEditCategoryDto>
{
    public EditCategoryDtoValidation()
    {
        RuleFor(x => x.id).GreaterThan(0).WithMessage(x => ErrorFluentValidation.MinLen);
        RuleFor(x => x.ParentCategoryId).GreaterThan(0).WithMessage(x => ErrorFluentValidation.MinLen);
        RuleFor(x => x.Name)
            .NotNull().WithMessage(x => ErrorFluentValidation.Null)
            .NotEmpty().WithMessage(x => ErrorFluentValidation.EmptyOrWhiteSpace);
    }
}