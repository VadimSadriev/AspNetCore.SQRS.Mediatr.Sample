using AutoMapper;
using SQRS.Mediatr.Sample.Application.Contracts.Orders;
using SQRS.Mediatr.Sample.DAL.Entities;

namespace SQRS.Mediatr.Sample.Application.Mapping.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderResponse>();
        }
    }
}
