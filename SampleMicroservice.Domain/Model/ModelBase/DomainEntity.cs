using MediatR;
using AutoMapper.Configuration.Annotations;

namespace SampleMicroservice.Domain.Model.ModelBase
{
    public abstract class DomainEntity
    {
        private List<INotification> _domainEvents = new List<INotification>();

        [Ignore]
        public IReadOnlyCollection<INotification> DomainEvents
        {
            get { return _domainEvents.AsReadOnly(); }
        }

        public void AddDomainEvent(INotification eventItem)
        {
            _domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(INotification eventItem)
        {
            _domainEvents.Remove(eventItem);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        public async Task RaiseDomainEventsAsync(IMediator mediator)
        {
            var domainEvents = DomainEvents.ToList();
            ClearDomainEvents();
            var tasks = domainEvents
                 .Select(async (domainEvent) =>
                 {
                     await mediator.Publish(domainEvent);
                 });

            await Task.WhenAll(tasks);
        }
    }
}
