using SQRS.Mediatr.Sample.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SQRS.Mediatr.Sample.Application.Customers
{
    public interface ICustomerService
    {
        Task<Customer> GetById(string id);

        Task<ICollection<Customer>> GetCustomers();
    }
}
