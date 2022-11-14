using MediatR;
using SampleMicroservice.Domain.Events;
using SampleMicroservice.Services.IntegrationEvents;

namespace SampleMicroservice.Services.DomainEventHandlers
{
    public class CustomerCreatedDomainEventHandler : INotificationHandler<CustomerCreatedDomainEvent>
    {
        public async Task Handle(CustomerCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var integrationEvent = new CustomerCreatedIntegrationEvent(
                notification.Customer.Id,
                notification.Customer.Name,
                notification.Customer.Birthdate,
                notification.Customer.Email);

            //Here should have the Service Bus client to publish this event

        }
    }
}
