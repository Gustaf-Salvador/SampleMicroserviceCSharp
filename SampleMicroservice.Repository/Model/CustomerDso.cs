using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleMicroservice.Domain.Events;

namespace SampleMicroservice.Repository.Model
{
    public class CustomerDso
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        public string Email { get; set; }

        public Guid AddressId { get; set; }

        public DateTime ModifiedDateUtc { get; set; }

        public DateTime CreatedDateUtc { get; set; }
    }
}
