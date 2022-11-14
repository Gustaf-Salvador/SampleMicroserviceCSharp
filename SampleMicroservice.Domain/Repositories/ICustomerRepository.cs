using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleMicroservice.Domain.Model;

namespace SampleMicroservice.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Task DeleteAsync(Customer customer);
        Task<Customer> GetCustomerById(Guid id);
        Task<IEnumerable<Customer>> ListCustomer();
        Task SaveAsync(Customer customer);
    }
}
