using FluentValidation;
using SQRS.Mediatr.Sample.Application.Customers.Commands;

namespace SQRS.Mediatr.Sample.Application.Validators.CustomerValidators
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(x => x.CustomerCreateContract.Name)
                .NotNull()
                .WithMessage("Please provide name in order to create customer")
                .NotEmpty()
                .WithMessage("Name cannot be empty");
        }
    }
}
