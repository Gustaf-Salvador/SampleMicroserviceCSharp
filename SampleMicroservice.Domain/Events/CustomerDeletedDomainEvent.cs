using MediatR;
using SampleMicroservice.Domain.Model;

namespace SampleMicroservice.Domain.Events
{
    public class CustomerDeletedDomainEvent : INotification
    {
        public CustomerDeletedDomainEvent(Customer customer)
        {
            Customer = customer;
        }

        public Customer Customer { get; }
    }
}
