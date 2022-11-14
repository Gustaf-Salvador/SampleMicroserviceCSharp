using Newtonsoft.Json;
using SampleMicroservice.Services.IntegrationEvents.IntegrationBase;

namespace SampleMicroservice.Services.IntegrationEvents
{
    public class CustomerCreatedIntegrationEvent : IntegrationEvent
    {
        public CustomerCreatedIntegrationEvent() : base()
        {

        }

        public CustomerCreatedIntegrationEvent(Guid customerId, string name, DateTime birthdate, string email) : this()
        {
            CustomerId = customerId;
            Name = name;
            Birthdate = birthdate;
            Email = email;
        }

        [JsonProperty("customer-id")]
        public Guid CustomerId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("birthdate")]
        public DateTime Birthdate { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
