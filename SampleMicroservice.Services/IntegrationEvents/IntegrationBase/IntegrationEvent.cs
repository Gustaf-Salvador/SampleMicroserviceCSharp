using Newtonsoft.Json;

namespace SampleMicroservice.Services.IntegrationEvents.IntegrationBase
{
    public abstract class IntegrationEvent
    {
        [JsonProperty("id")]
        public Guid Id { get; }

        [JsonProperty("source-system")]
        public string SourceSystem { get; set; }

        [JsonProperty("creation-date-utc")]
        public DateTime CreationDateUtc { get; }

        [JsonProperty("external-id-key")]
        public virtual string ExternalIdKey => nameof(Id);

        [JsonProperty("event-type")]
        public virtual string EventType => this.GetType().Name;

        public IntegrationEvent()
        {
            Id = Guid.NewGuid();
            SourceSystem = "SimpleMicroservice";
            CreationDateUtc = DateTime.UtcNow;
        }
    }
}
