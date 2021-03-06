﻿using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using SQRS.Mediatr.Sample.Infrastructure.Middlewares;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace SQRS.Mediatr.Sample.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services, params Assembly[] assembliesWithModels)
        {
            var xmlFilePaths = assembliesWithModels
                .Select(x => Path.Combine(AppContext.BaseDirectory, $"{x.GetName().Name}.xml"));

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "SQRS Mediatr Sample", Version = "v1" });
                x.DescribeAllParametersInCamelCase();

                foreach (var xmlFilePath in xmlFilePaths)
                {
                    x.IncludeXmlComments(xmlFilePath);
                }
            });

            return services;
        }

        public static IApplicationBuilder UseSwagger(this IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("v1/swagger.json", "SQRS Mediatr Sample");
            });

            return app;
        }

        public static IServiceCollection AddMapper(this IServiceCollection services, params Assembly[] assembliesWithProfiles)
        {
            services.AddAutoMapper(assembliesWithProfiles);

            return services;
        }

        public static IApplicationBuilder AddErroHanldingMiddleWare(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();

            return app;
        }

        public static IServiceCollection AddValidators(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.AddValidatorsFromAssemblies(assemblies);

            return services;
        }
    }
}
