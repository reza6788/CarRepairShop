using CarRepairShop.Application.Commands.RepairOrder;
using FluentValidation;

namespace CarRepairShop.Application.Validators.RepairOrder;

public class CreateRepairOrderCommandValidator : AbstractValidator<CreateRepairOrderCommand>
{
    public CreateRepairOrderCommandValidator()
    {
        RuleFor(x=>x.RepairOrder.RepairCostCurrency)
            .NotEmpty().WithMessage("Repair cost currency is required");
    }
}