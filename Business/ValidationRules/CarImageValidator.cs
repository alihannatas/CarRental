using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules;

public class CarImageValidator : AbstractValidator<CarImage>
{
    public CarImageValidator()
    {
        RuleFor(p => p.ImagePath).Empty();
        RuleFor(p => p.Id).NotEmpty();
        RuleFor(p => p.CarId).NotEmpty();
    }
}