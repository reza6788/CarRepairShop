using CarRepairShop.Application.Commands.Customer;
using FluentValidation;

namespace CarRepairShop.Application.Validators.Customer;

public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerCommandValidator()
    {
        RuleFor(x => x.Customer.Id)
            .NotEmpty().WithMessage("Customer id is required");
        
        RuleFor(x => x.Customer.FirstName)
            .NotEmpty().WithMessage("Firstname is required");

        RuleFor(x => x.Customer.LastName)
            .NotEmpty().WithMessage("Lastname is required");

        RuleFor(x => x.Customer.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required");
    }
}