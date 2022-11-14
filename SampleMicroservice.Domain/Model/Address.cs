using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleMicroservice.Domain.Repositories;

namespace SampleMicroservice.Domain.Model
{
    public class Address
    {
        public Guid Id { get; set; }

        public string Street { get; set; }

        public int Number { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string PostalCode { get; set; }

        public static async Task<Address> GetAddress(IAddressRepository addressRepository, Address address)
        {
            try
            {
                var savedAddress = await addressRepository.GetAddress(address.Country, address.PostalCode, address.Number);

                if (savedAddress!= null)
                {
                    return savedAddress;
                }
            }
            catch (KeyNotFoundException)
            {
                address.Id = Guid.NewGuid();
                await addressRepository.SaveAsync(address);
            }

            return address;
        }
    }
}
