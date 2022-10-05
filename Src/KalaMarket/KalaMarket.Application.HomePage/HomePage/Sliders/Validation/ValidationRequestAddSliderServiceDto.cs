using System.Xml;
using FluentValidation;
using FluentValidation.Validators;
using KalaMarket.Application.HomePage.HomePage.Sliders.Cmd.AddSlider;
using KalaMarket.Domain.HomePage.HomePages;
using KalaMarket.Resourses;
using KalaMarket.Shared;

namespace KalaMarket.Application.HomePage.HomePage.Sliders.Validation;

public class ValidationRequestAddSliderServiceDto : AbstractValidator<RequestAddSliderServiceDto>
{
    public ValidationRequestAddSliderServiceDto()
    {
        RuleFor(x => x.SliderType).IsInEnum().WithMessage("نوع اسلایدر نا معتبر است");
        RuleFor(x => x.Link).MaximumLength(KalaMarketConstants.MaxLength.Name*2).WithMessage(ErrorFluentValidation.MaxLen);
        RuleFor(x => x.Src).MaximumLength(KalaMarketConstants.MaxLength.Name*2).WithMessage(ErrorFluentValidation.MaxLen);
    }
}
