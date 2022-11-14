using System.Text.Json.Serialization;

namespace SampleMicroservice.Services.Model
{
    public class FullCustomerDto : CustomerDto
    {
        public Guid Id { get; set; }

    }
}
