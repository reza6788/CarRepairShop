using CarRepairShop.Application.Commands.Customer;
using FluentValidation;

namespace CarRepairShop.Application.Validators.Customer;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(x => x.Customer.FirstName)
            .NotEmpty().WithMessage("Firstname is required");

        RuleFor(x => x.Customer.LastName)
            .NotEmpty().WithMessage("Lastname is required");

        RuleFor(x => x.Customer.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required");
    }
}