using MediatR;
using SampleMicroservice.Domain.Events;
using SampleMicroservice.Domain.Model;
using SampleMicroservice.Services.IntegrationEvents;

namespace SampleMicroservice.Services.DomainEventHandlers
{
    public class CustomerDeletedDomainEventHandler : INotificationHandler<CustomerDeletedDomainEvent>
    {
        public async Task Handle(CustomerDeletedDomainEvent notification, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var integrationEvent = new CustomerDeletedIntegrationEvent(notification.Customer.Id);

            //Here should have the Service Bus client to publish this event
        }
    }
}
