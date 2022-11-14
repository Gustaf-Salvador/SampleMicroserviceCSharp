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
    public class ListCustomerRequestEventHandler : IRequestHandler<ListCustomerRequestEvent, IEnumerable<Customer>>
    {
        private readonly ICustomerRepository _customerRepository;

        public ListCustomerRequestEventHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<Customer>> Handle(ListCustomerRequestEvent request, CancellationToken cancellationToken)
        {
            return await Customer.ListCustomers(_customerRepository);
        }
    }
}
