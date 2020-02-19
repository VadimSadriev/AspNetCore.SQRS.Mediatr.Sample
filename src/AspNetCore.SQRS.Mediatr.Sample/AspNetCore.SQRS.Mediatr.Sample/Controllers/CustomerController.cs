using MediatR;
using Microsoft.AspNetCore.Mvc;
using SQRS.Mediatr.Sample.Application.Customers.Commands;
using SQRS.Mediatr.Sample.Infrastructure.Contracts.Customers;
using System.Threading.Tasks;

namespace AspNetCore.SQRS.Mediatr.Sample.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CustomerCreateContract customerCreateContract)
        {
            var command = new CreateCustomerCommand(customerCreateContract);

            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
