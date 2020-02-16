using Microsoft.EntityFrameworkCore;
using SQRS.Mediatr.Sample.DAL;
using SQRS.Mediatr.Sample.DAL.Entities;
using SQRS.Mediatr.Sample.Infrastructure.Contracts.Orders;
using SQRS.Mediatr.Sample.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SQRS.Mediatr.Sample.Application.Orders
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _context;

        public OrderService(DataContext context)
        {
            _context = context;
        }

        public async Task<Order> Create(OrderCreateContract orderCreateContract)
        {
            var order = new Order
            {
                Name = orderCreateContract.Name,
                Description = orderCreateContract.Description,
                CustomerId = orderCreateContract.CustomerId
            };

            try
            {
                await _context.Orders.AddAsync(order);

                await _context.SaveChangesAsync();

                return await GetByIdInternal(order.Id);
            }
            catch (DbUpdateException ex)
            {
                throw new DomainException("An erro occured during creating new order", ex);
            }
        }

        public async Task<Order> GetById(string id)
        {
            return await GetByIdInternal(id);
        }

        public async Task<ICollection<Order>> GetAllOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        private async Task<Order> GetByIdInternal(string id)
        {
            return await _context.Orders.FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new DomainException($"Order with id: {id} not found");
        }
    }
}
