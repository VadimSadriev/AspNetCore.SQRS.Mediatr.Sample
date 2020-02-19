using AutoMapper;
using MediatR;
using SQRS.Mediatr.Sample.Application.Contracts.Customers;
using SQRS.Mediatr.Sample.Application.Customers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SQRS.Mediatr.Sample.Application.Customers.Handlers
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, CustomerResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerService _customerService;

        public CreateCustomerHandler(ICustomerService customerService, IMapper mapper)
        {
            _mapper = mapper;
            _customerService = customerService;
        }

        public async Task<CustomerResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var newCustomer = await _customerService.Create(request.CustomerCreateContract);

            return _mapper.Map<CustomerResponse>(newCustomer);
        }
    }
}
