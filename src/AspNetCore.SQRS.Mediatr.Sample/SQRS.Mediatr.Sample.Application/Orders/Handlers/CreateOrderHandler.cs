using AutoMapper;
using MediatR;
using SQRS.Mediatr.Sample.Application.Contracts.Orders;
using SQRS.Mediatr.Sample.Application.Orders.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace SQRS.Mediatr.Sample.Application.Orders.Handlers
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, OrderResponse>
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public CreateOrderHandler(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        public async Task<OrderResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var newOrder = await _orderService.Create(request.CreateContract);

            return _mapper.Map<OrderResponse>(newOrder);
        }
    }
}
