﻿using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SQRS.Mediatr.Sample.Application.Customers;
using SQRS.Mediatr.Sample.Application.Orders;
using System.Reflection;

namespace SQRS.Mediatr.Sample.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IOrderService, OrderService>();

            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
