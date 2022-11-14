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
    public class CreateCustomerRequestEventHandler : IRequestHandler<CreateCustomerRequestEvent, Customer>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IAddressRepository _addressRepository;

        public CreateCustomerRequestEventHandler(ICustomerRepository customerRepository, IAddressRepository addressRepository)
        {
            _customerRepository = customerRepository;
            _addressRepository = addressRepository;
        }

        public async Task<Customer> Handle(CreateCustomerRequestEvent request, CancellationToken cancellationToken)
        {
            var address = await Address.GetAddress(_addressRepository, request.Address);

            var customer = await Customer.CreateCustomer(_customerRepository, _addressRepository, request.Name, request.Birthdate, request.Email, address.Id);

            return customer;
        }
    }
}
