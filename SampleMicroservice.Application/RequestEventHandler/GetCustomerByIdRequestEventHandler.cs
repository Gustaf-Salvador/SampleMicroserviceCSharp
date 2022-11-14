using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleMicroservice.Application.RequestEvent;
using SampleMicroservice.Domain.Model;
using SampleMicroservice.Domain.Repositories;

namespace SampleMicroservice.Application.RequestEventHandler
{
    public class GetCustomerByIdRequestEventHandler : IRequestHandler<GetCustomerByIdRequestEvent, Customer>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerByIdRequestEventHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> Handle(GetCustomerByIdRequestEvent request, CancellationToken cancellationToken)
        {
            return await Customer.GetCustomerById(_customerRepository, request.Id);
        }
    }
}
