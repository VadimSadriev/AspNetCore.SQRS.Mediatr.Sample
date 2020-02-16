using MediatR;
using SQRS.Mediatr.Sample.Application.Contracts.Orders;

namespace SQRS.Mediatr.Sample.Application.Orders.Queries
{
    public class GetOrderByIdQuery : IRequest<OrderResponse>
    {
        public string Id { get; }

        public GetOrderByIdQuery(string id)
        {
            Id = id;
        }
    }
}
