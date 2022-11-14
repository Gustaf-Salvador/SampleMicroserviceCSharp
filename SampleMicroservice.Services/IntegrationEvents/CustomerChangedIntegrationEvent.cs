using Newtonsoft.Json;
using SampleMicroservice.Services.IntegrationEvents.IntegrationBase;

namespace SampleMicroservice.Services.IntegrationEvents
{
    public class CustomerChangedIntegrationEvent : IntegrationEvent
    {
        public CustomerChangedIntegrationEvent() : base()
        {

        }

        public CustomerChangedIntegrationEvent(Guid customerId, string changedField, DateTime modifiedDateUtc, string? oldValue, string? newValue) : this()
        {
            CustomerId = customerId;
            ChangedField = changedField;
            ModifiedDateUtc = modifiedDateUtc;
            OldValue = oldValue;
            NewValue = newValue;
        }

        [JsonProperty("customer-id")]
        public Guid CustomerId { get; set; }

        [JsonProperty("changed-field")]
        public string ChangedField { get; set; }

        [JsonProperty("modified-date-utc")]
        public DateTime ModifiedDateUtc { get; set; }

        [JsonProperty("old-value")]
        public string? OldValue { get; set; }

        [JsonProperty("new-value")]
        public string? NewValue { get; set; }
    }
}
