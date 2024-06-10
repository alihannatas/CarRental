using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules;

public class RentalValidator : AbstractValidator<Rental>
{
    public RentalValidator()
    {
        RuleFor(p => p.Id).NotEmpty();
        RuleFor(p => p.CarId).NotEmpty();
        RuleFor(p => p.CustomerId).NotEmpty();
        RuleFor(p => p.RentDate).NotEmpty();
        RuleFor(p => p.ReturnDate).Empty();
    }
}