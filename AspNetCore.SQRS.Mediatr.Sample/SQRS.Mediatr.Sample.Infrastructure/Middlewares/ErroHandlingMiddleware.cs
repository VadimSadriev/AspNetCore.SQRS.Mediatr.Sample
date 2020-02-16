using AutoMapper;
using Microsoft.AspNetCore.Http;
using SQRS.Mediatr.Sample.Infrastructure.Contracts.Exception;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace SQRS.Mediatr.Sample.Infrastructure.Middlewares
{
    public class ErroHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IMapper _mapper;

        /// <summary> Middleware for catching and serializing all exceptions occured during request  </summary>
        public ErroHandlingMiddleware(RequestDelegate next, IMapper mapper)
        {
            _next = next;
            _mapper = mapper;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next.Invoke(httpContext);
            }
            catch (Exception ex)
            {
                await HandleAsync(httpContext, ex);
            }
        }

        private async Task HandleAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            httpContext.Response.ContentType = "application/json";

            var exceptionContract = _mapper.Map<ExceptionContract>(exception);

            var result = JsonSerializer.Serialize<ExceptionContract>(exceptionContract,
                new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            await httpContext.Response.WriteAsync(result);
        }
    }
}
