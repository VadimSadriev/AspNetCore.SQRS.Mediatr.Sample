using AutoMapper;
using MediatR;
using SQRS.Mediatr.Sample.Application.Contracts.Orders;
using SQRS.Mediatr.Sample.Application.Orders.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SQRS.Mediatr.Sample.Application.Orders.Handlers
{
    public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersQuery, List<OrderResponse>>
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public GetAllOrdersHandler(
            IOrderService orderService,
            IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        public async Task<List<OrderResponse>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderService.GetAllOrders();

            return _mapper.Map<List<OrderResponse>>(orders);
        }
    }
}
