using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleMicroservice.Domain.Model;
using SampleMicroservice.Domain.Repositories;
using SampleMicroservice.Repository.Model;

namespace SampleMicroservice.Repository.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly List<AddressDso> addressesDso = new();
        private readonly IMapper _mapper;

        public AddressRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task DeleteAsync(Address address)
        {
            await Task.CompletedTask;

            var addressDso = _mapper.Map<Address, AddressDso>(address);

            addressesDso.Remove(addressDso);
        }

        public async Task<Address> GetAddress(string country, string postalCode, int number)
        {
            await Task.CompletedTask;

            var addressDso = addressesDso.FirstOrDefault(addressDso => 
            country.Equals(addressDso.Country) &&
            postalCode.Equals(addressDso.PostalCode) &&
            number.Equals(addressDso.Number));

            if (addressDso == null)
            {
                throw new KeyNotFoundException("The Address was not found");
            }

            var customer = _mapper.Map<AddressDso, Address>(addressDso);

            return customer;
        }

        public async Task<Address> GetAddressById(Guid id)
        {
            await Task.CompletedTask;

            var addressDso = addressesDso.FirstOrDefault(addressDso => id.Equals(addressDso.Id));

            if (addressDso == null)
            {
                throw new KeyNotFoundException("The Address was not found");
            }

            var customer = _mapper.Map<AddressDso, Address>(addressDso);

            return customer;
        }

        public async Task<IEnumerable<Address>> ListAddresses()
        {
            var addresses = _mapper.Map<List<AddressDso>, List<Address>>(addressesDso);

            await Task.CompletedTask;
            return addresses;
        }

        public async Task SaveAsync(Address address)
        {
            await Task.CompletedTask;

            var addressDso = _mapper.Map<Address, AddressDso>(address);

            addressesDso.Add(addressDso);
        }
    }
}
