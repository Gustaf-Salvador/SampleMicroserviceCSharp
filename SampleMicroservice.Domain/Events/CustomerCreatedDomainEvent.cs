using MediatR;
using SampleMicroservice.Domain.Model;

namespace SampleMicroservice.Domain.Events
{
    public class CustomerCreatedDomainEvent : INotification
    {
        public CustomerCreatedDomainEvent(Customer customer)
        {
            Customer = customer;
        }

        public Customer Customer { get; }
    }
}
