using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQRS.Mediatr.Sample.Application.Contracts.Orders;
using SQRS.Mediatr.Sample.Application.Orders.Commands;
using SQRS.Mediatr.Sample.Application.Orders.Queries;
using SQRS.Mediatr.Sample.Infrastructure.Contracts.Exception;
using SQRS.Mediatr.Sample.Infrastructure.Contracts.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.SQRS.Mediatr.Sample.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IMediator _mediatr;

        public OrderController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ICollection<OrderResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionContract), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ExceptionContract), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllOrders()
        {
            var query = new GetAllOrdersQuery();

            var result = await _mediatr.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(OrderResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionContract), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ExceptionContract), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById([FromRoute]string id)
        {
            var query = new GetOrderByIdQuery(id);

            var result = await _mediatr.Send(query);

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(OrderResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionContract), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ExceptionContract), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody]OrderCreateContract orderCreateContract)
        {
            var command = new CreateOrderCommand
            {
                CreateContract = orderCreateContract
            };

            var result = await _mediatr.Send(command);

            var orderUri = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/api/order/{result.Id}";

            return Created(orderUri, result);
        }
    }
}
