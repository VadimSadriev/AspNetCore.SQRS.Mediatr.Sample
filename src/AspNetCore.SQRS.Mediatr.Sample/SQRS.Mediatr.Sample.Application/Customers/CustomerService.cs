﻿using Microsoft.EntityFrameworkCore;
using SQRS.Mediatr.Sample.DAL;
using SQRS.Mediatr.Sample.DAL.Entities;
using SQRS.Mediatr.Sample.Infrastructure.Contracts.Customers;
using SQRS.Mediatr.Sample.Infrastructure.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SQRS.Mediatr.Sample.Application.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly DataContext _context;

        public CustomerService(DataContext context)
        {
            _context = context;
        }

        public async Task<Customer> Create(CustomerCreateContract customerCreateContract)
        {
            var newCustomer = new Customer
            {
                Name = customerCreateContract.Name
            };

            try
            {
                await _context.Customers.AddAsync(newCustomer);

                await _context.SaveChangesAsync();

                return await GetByIdInternal(newCustomer.Id);
            }
            catch (DbUpdateException ex)
            {
                throw new DomainException("An error occured during customer creation", ex);
            }
        }

        public async Task<Customer> GetById(string id)
        {
            return await GetByIdInternal(id);
        }

        public async Task<ICollection<Customer>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        private async Task<Customer> GetByIdInternal(string id)
        {
            return await _context.Customers.FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new DomainException($"Customer with id: {id} not found");
        }
    }
}
