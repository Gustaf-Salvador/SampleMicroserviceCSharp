using Newtonsoft.Json;
using SampleMicroservice.Services.IntegrationEvents.IntegrationBase;

namespace SampleMicroservice.Services.IntegrationEvents
{
    public class CustomerDeletedIntegrationEvent : IntegrationEvent
    {
        public CustomerDeletedIntegrationEvent() : base()
        {

        }

        public CustomerDeletedIntegrationEvent(Guid customerId) : this()
        {
            CustomerId = customerId;
        }

        [JsonProperty("customer-id")]
        public Guid CustomerId { get; set; }
    }
}
