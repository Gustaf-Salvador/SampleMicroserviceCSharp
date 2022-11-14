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
    public class UpdateCustomerRequestEventHandler : IRequestHandler<UpdateCustomerRequestEvent, Customer>
    {
        private readonly ICustomerRepository _customerRepository;

        public UpdateCustomerRequestEventHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> Handle(UpdateCustomerRequestEvent request, CancellationToken cancellationToken)
        {
            var customer = await Customer.GetCustomerById(_customerRepository, request.Id);

            request.CustomerPatch.ApplyTo(customer);

            await customer.SaveAsync();

            return customer;
        }
    }
}
