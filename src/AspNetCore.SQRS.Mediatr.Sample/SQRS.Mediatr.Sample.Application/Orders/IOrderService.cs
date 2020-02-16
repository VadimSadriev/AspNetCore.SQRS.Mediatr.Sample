using SQRS.Mediatr.Sample.DAL.Entities;
using SQRS.Mediatr.Sample.Infrastructure.Contracts.Orders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SQRS.Mediatr.Sample.Application.Orders
{
    public interface IOrderService
    {
        // ye we probably should not use web contract here but 
        // for example purposes we might do this
        Task<Order> Create(OrderCreateContract orderCreateContract); 

        Task<Order> GetById(string id);

        Task<ICollection<Order>> GetAllOrders();
    }
}
