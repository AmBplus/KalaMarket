using FluentValidation;
using KalaMarket.Application.Product.Services.Product.CategoryServices.Commands.AddNewCategory;
using KalaMarket.Resourses;

namespace KalaMarket.Application.Product.Validations.Category;

public class AddCategoryDtoValidation : AbstractValidator<RequestAddNewCategoryDto>
{
    public AddCategoryDtoValidation()
    {
        RuleFor(x => x.Name)
            .NotNull().WithMessage(x => ErrorFluentValidation.Null)
            .NotEmpty().WithMessage(x => ErrorFluentValidation.EmptyOrWhiteSpace);
    }
}