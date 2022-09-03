using FluentValidation;
using KalaMarket.Application.Services.Category.Commands.AddNewCategory;
using KalaMarket.Resourses;

namespace KalaMarket.Application.Validations.Category;

public class AddCategoryDtoValidation : AbstractValidator<RequestAddNewCategoryDto>
{
    public AddCategoryDtoValidation()
    {
        RuleFor(x => x.Name)
            .NotNull().WithMessage(x => ErrorFluentValidation.Null)
            .NotEmpty().WithMessage(x => ErrorFluentValidation.EmptyOrWhiteSpace);
    }
}