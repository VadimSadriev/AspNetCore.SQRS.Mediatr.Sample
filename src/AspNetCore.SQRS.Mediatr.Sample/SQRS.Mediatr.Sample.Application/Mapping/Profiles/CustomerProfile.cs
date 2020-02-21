using AutoMapper;
using SQRS.Mediatr.Sample.Application.Contracts.Customers;
using SQRS.Mediatr.Sample.DAL.Entities;

namespace SQRS.Mediatr.Sample.Application.Mapping.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerResponse>();
        }
    }
}
