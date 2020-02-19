using SQRS.Mediatr.Sample.DAL.Entities;
using SQRS.Mediatr.Sample.Infrastructure.Contracts.Customers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SQRS.Mediatr.Sample.Application.Customers
{
    public interface ICustomerService
    {
        Task<Customer> Create(CustomerCreateContract customerCreateContract);

        Task<Customer> GetById(string id);

        Task<ICollection<Customer>> GetCustomers();
    }
}
