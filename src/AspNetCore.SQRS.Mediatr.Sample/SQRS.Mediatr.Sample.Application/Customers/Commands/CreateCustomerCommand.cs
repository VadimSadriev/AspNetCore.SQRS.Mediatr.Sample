using MediatR;
using SQRS.Mediatr.Sample.Application.Contracts.Customers;
using SQRS.Mediatr.Sample.Infrastructure.Contracts.Customers;

namespace SQRS.Mediatr.Sample.Application.Customers.Commands
{
    public class CreateCustomerCommand : IRequest<CustomerResponse>
    {
        public CreateCustomerCommand(CustomerCreateContract customerCreateContract)
        {
            CustomerCreateContract = customerCreateContract;
        }

        public CustomerCreateContract CustomerCreateContract { get; set; }
    }
}