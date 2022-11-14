using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleMicroservice.Domain.Model;
using SampleMicroservice.Domain.Repositories;
using SampleMicroservice.Repository.Model;

namespace SampleMicroservice.Repository.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly List<CustomerDso> customersDso = new();
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CustomerRepository(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task DeleteAsync(Customer customer)
        {
            customersDso.RemoveAll(ct => ct.Id.Equals(customer.Id));

            await customer.RaiseDomainEventsAsync(_mediator);
        }

        public async Task<Customer> GetCustomerById(Guid id)
        {
            await Task.CompletedTask;

            var customerDso = customersDso.FirstOrDefault(customerDso => id.Equals(customerDso.Id));

            if (customerDso == null)
            {
                throw new KeyNotFoundException("The Customer Id was not found");
            }

            var customer = _mapper.Map<CustomerDso, Customer>(customerDso);

            return customer;
        }

        public async Task<IEnumerable<Customer>> ListCustomer()
        {
            var customers = _mapper.Map<List<CustomerDso>, List<Customer>>(customersDso);

            await Task.CompletedTask;
            return customers;
        }

        public async Task SaveAsync(Customer customer)
        {
            var customerDso = _mapper.Map<Customer, CustomerDso>(customer);

            customersDso.RemoveAll(ct => ct.Id.Equals(customer.Id));

            customersDso.Add(customerDso);

            await customer.RaiseDomainEventsAsync(_mediator);
        }
    }
}
