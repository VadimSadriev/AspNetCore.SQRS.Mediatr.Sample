using MediatR;
using SQRS.Mediatr.Sample.Application.Contracts.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQRS.Mediatr.Sample.Application.Orders.Queries
{
   public class GetAllOrdersQuery : IRequest<List<OrderResponse>>
    {
    }
}
