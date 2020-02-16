using AutoMapper;
using MediatR;
using SQRS.Mediatr.Sample.Application.Contracts.Orders;
using SQRS.Mediatr.Sample.Application.Orders.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace SQRS.Mediatr.Sample.Application.Orders.Handlers
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderResponse>
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public GetOrderByIdQueryHandler(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        public async Task<OrderResponse> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderService.GetById(request.Id);

            return _mapper.Map<OrderResponse>(order);
        }
    }
}