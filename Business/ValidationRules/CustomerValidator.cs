using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules;

public class CustomerValidator : AbstractValidator<Customer>
{
    public CustomerValidator()
    {
        RuleFor(p => p.Id).NotEmpty();
        RuleFor(p => p.CompanyName).NotEmpty();
        RuleFor(p => p.UserId).NotEmpty();
    }
}