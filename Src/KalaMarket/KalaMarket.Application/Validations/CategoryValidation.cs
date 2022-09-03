using FluentValidation;
using KalaMarket.Application.Services.Product.Commands.AddNewCategory;
using KalaMarket.Resourses;

namespace KalaMarket.Application.Validations;

public class CategoryValidation : AbstractValidator<RequestAddNewCategoryDto>
{
    public CategoryValidation()
    {
        RuleFor(x => x.Name)
            .NotNull().WithMessage(x=> ErrorFluentValidation.Null)
            .NotEmpty().WithMessage(x=>ErrorFluentValidation.EmptyOrWhiteSpace);
    }
}