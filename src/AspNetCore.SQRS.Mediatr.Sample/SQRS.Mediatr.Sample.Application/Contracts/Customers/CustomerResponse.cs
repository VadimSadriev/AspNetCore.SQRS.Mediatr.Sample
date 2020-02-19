using SQRS.Mediatr.Sample.Application.Contracts.Orders;
using System.Collections.Generic;

namespace SQRS.Mediatr.Sample.Application.Contracts.Customers
{
    public class CustomerResponse
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<OrderResponse> Orders { get; set; }
    }
}
