using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(p => p.Id).NotEmpty();
        RuleFor(p => p.FirstName).NotEmpty().MinimumLength(3);
        RuleFor(p => p.LastName).NotEmpty().MinimumLength(2);
        RuleFor(p => p.Password).NotEmpty().MinimumLength(8);
        RuleFor(p => p.Email).NotEmpty().EmailAddress();
    }
}