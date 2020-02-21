using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SQRS.Mediatr.Sample.Application.Orders.Commands;
using SQRS.Mediatr.Sample.DAL;

namespace SQRS.Mediatr.Sample.Application.Validators.OrderValidations
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator(DataContext context)
        {
            RuleFor(x => x.CreateContract.Name)
                .NotEmpty()
                .WithMessage("Name cannot be empty")
                .NotNull()
                .WithMessage("Please provide name for new order");

            RuleFor(x => x.CreateContract.CustomerId)
                .MustAsync(async (request, val, token) =>
                {
                    return await context.Customers.AnyAsync(x => x.Id == request.CreateContract.CustomerId);
                })
                .WithMessage(x => $"Customer with id : {x.CreateContract.CustomerId} not found");
        }
    }
}
