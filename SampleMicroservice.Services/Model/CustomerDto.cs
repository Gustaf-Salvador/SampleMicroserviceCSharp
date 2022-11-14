using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace SampleMicroservice.Services.Model
{
    public class CustomerDto
    {
        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        public string Email { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public AddressDto Address { get; set; }
    }
}
