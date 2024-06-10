using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules;

public class CarValidator : AbstractValidator<Car>
{
    public CarValidator()
    {
        RuleFor(p => p.Id).NotEmpty();
        RuleFor(p => p.BrandId).NotEmpty();
        RuleFor(p => p.ColorId).NotEmpty();
        RuleFor(p => p.ModelYear).NotEmpty().GreaterThanOrEqualTo(1950);
        RuleFor(p => p.DailyPrice).GreaterThanOrEqualTo(0);
        RuleFor(p => p.Description).NotEmpty().MinimumLength(10);
    }
}