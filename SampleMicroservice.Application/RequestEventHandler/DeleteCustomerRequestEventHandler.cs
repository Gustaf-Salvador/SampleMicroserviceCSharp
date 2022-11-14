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
    public class DeleteCustomerRequestEventHandler : INotificationHandler<DeleteCustomerRequestEvent>
    {
        private readonly ICustomerRepository _customerRepository;

        public DeleteCustomerRequestEventHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task Handle(DeleteCustomerRequestEvent request, CancellationToken cancellationToken)
        {
            var customer = await Customer.GetCustomerById(_customerRepository, request.Id);

            await customer.DeleteAsync();
        }
    }
}
