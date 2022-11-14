using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleMicroservice.Domain.Model;

namespace SampleMicroservice.Domain.Repositories
{
    public interface IAddressRepository
    {
        Task DeleteAsync(Address address);
        Task<Address> GetAddress(string country, string postalCode, int number);
        Task<Address> GetAddressById(Guid id);
        Task<IEnumerable<Address>> ListAddresses();
        Task SaveAsync(Address address);
    }
}
