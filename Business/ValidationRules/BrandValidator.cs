using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules;

public class BrandValidator : AbstractValidator<Brand>
{
    public BrandValidator()
    {   
      
        RuleFor(p => p.Name).NotEmpty();
        RuleFor(p => p.Name).MinimumLength(5);
    }
}