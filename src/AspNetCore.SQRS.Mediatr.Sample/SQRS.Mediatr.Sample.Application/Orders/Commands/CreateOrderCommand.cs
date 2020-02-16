using MediatR;
using SQRS.Mediatr.Sample.Application.Contracts.Orders;
using SQRS.Mediatr.Sample.Infrastructure.Contracts.Orders;

namespace SQRS.Mediatr.Sample.Application.Orders.Commands
{
    public class CreateOrderCommand : IRequest<OrderResponse>
    {
        public OrderCreateContract CreateContract { get; set; }
    }
}
