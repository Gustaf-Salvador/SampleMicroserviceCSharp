using MediatR;
using SampleMicroservice.Domain.Events;
using SampleMicroservice.Services.IntegrationEvents;

namespace SampleMicroservice.Services.DomainEventHandlers
{
    public class CustomerChangedDomainEventHandler : INotificationHandler<CustomerChangedDomainEvent>
    {
        private readonly ILogger<CustomerChangedDomainEventHandler> _logger;

        public CustomerChangedDomainEventHandler(ILogger<CustomerChangedDomainEventHandler> logger)
        {
            _logger = logger;
        }

        public async Task Handle(CustomerChangedDomainEvent notification, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            if (notification?.NewValue == null)
            {
                _logger.LogWarning("Error on new value field");
            }

            var integrationEvent = new CustomerChangedIntegrationEvent(notification.CustomerId, 
                notification.ChangedField, 
                notification.ModifiedDateUtc,
                notification?.OldValue != null ? notification?.OldValue?.ToString() : string.Empty, 
                notification?.NewValue?.ToString());

            //Here should have the Service Bus client to publish this event
        }
    }
}
