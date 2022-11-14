using Microsoft.AspNetCore.JsonPatch;
using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleMicroservice.Domain.Events;
using SampleMicroservice.Domain.Model.ModelBase;
using SampleMicroservice.Domain.Repositories;

namespace SampleMicroservice.Domain.Model
{
    public class Customer : DomainEntity
    {
        protected readonly ICustomerRepository _customerRepository;
        protected readonly IAddressRepository _addressRepository;

        public Customer(ICustomerRepository customerRepository, IAddressRepository addressRepository)
        {
            _customerRepository = customerRepository;
            _addressRepository = addressRepository;

            _address = new AsyncLazy<Address>(async () => await _addressRepository.GetAddressById(AddressId));
        }

        private Customer(ICustomerRepository customerRepository,
            IAddressRepository addressRepository,
            string name,
            DateTime birthdate,
            string email,
            Guid addressId) : this(customerRepository, addressRepository)
        {
            Id = Guid.NewGuid();
            CreatedDateUtc = DateTime.UtcNow;
            ModifiedDateUtc = DateTime.UtcNow;
            Name = name;
            Birthdate = birthdate;
            Email = email;
            AddressId = addressId;

            AddDomainEvent(new CustomerCreatedDomainEvent(this));
        }

        public static async Task<IEnumerable<Customer>> ListCustomers(ICustomerRepository customerRepository)
        {
            return await customerRepository.ListCustomer();
        }

        public static async Task<Customer> CreateCustomer(ICustomerRepository _customerRepository, IAddressRepository _addressRepository, string name, DateTime birthdate, string email, Guid addressId)
        {
            var customer = new Customer(_customerRepository, _addressRepository, name, birthdate, email, addressId);

            await customer.SaveAsync();

            return customer;
        }

        public static async Task<Customer> GetCustomerById(ICustomerRepository customerRepository, Guid id)
        {
            return await customerRepository.GetCustomerById(id);
        }

        public async Task SaveAsync()
        {
            ModifiedDateUtc = DateTime.UtcNow;
            await _customerRepository.SaveAsync(this);
        }

        public async Task DeleteAsync()
        {
            ModifiedDateUtc = DateTime.UtcNow;
            AddDomainEvent(new CustomerDeletedDomainEvent(this));

            await _customerRepository.DeleteAsync(this);
        }

        public Guid Id { get; set; }

        private string _name;

        public string Name 
        { 
            get 
            { 
                return _name; 
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(_name) && _name != value)
                {
                    AddDomainEvent(new CustomerChangedDomainEvent(Id, "Name", _name, value));
                }

                _name = value;
            }
        }

        private DateTime _birthdate;
        public DateTime Birthdate
        {
            get
            {
                return _birthdate;
            }
            set
            {
                if (_birthdate != default && _birthdate != value)
                {
                    AddDomainEvent(new CustomerChangedDomainEvent(Id, "Birthdate", _birthdate, value));
                }

                _birthdate = value;
            }
        }

        private string _email;

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(_email) && _email != value)
                {
                    AddDomainEvent(new CustomerChangedDomainEvent(Id, "Email", _email, value));
                }

                _email = value;
            }
        }

        private Guid AddressId;

        public Address Address => _address.ConfigureAwait(false).GetAwaiter().GetResult();
        private AsyncLazy<Address> _address;


        public DateTime ModifiedDateUtc { get; private set; }

        public DateTime CreatedDateUtc { get; private set; }

    }
}
