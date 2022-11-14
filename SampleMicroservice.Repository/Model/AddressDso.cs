using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleMicroservice.Domain.Events;

namespace SampleMicroservice.Repository.Model
{
    public class AddressDso
    {
        public Guid Id { get; set; }

        public string Street { get; set; }

        public int Number { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string PostalCode { get; set; }
    }
}
