using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules;

public class ColorValidator : AbstractValidator<Color>
{
    public ColorValidator()
    {
        RuleFor(p => p.Id).NotEmpty();
        RuleFor(p => p.Name).NotEmpty().MinimumLength(2);
        
    }
}