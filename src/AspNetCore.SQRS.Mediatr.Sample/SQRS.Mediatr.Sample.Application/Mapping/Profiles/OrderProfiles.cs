using AutoMapper;
using SQRS.Mediatr.Sample.Application.Contracts.Orders;
using SQRS.Mediatr.Sample.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQRS.Mediatr.Sample.Application.Mapping.Profiles
{
    public class OrderProfiles : Profile
    {
        public OrderProfiles()
        {
            CreateMap<Order, OrderResponse>();
        }
    }
}
