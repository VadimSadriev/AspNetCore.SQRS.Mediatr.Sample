using SQRS.Mediatr.Sample.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SQRS.Mediatr.Sample.Application.Orders
{
    public interface IOrderService
    {
        Task<Order> GetById(string id);

        Task<ICollection<Order>> GetOrders();
    }
}
