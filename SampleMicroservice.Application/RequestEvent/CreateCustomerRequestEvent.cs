using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleMicroservice.Domain.Model;

namespace SampleMicroservice.Application.RequestEvent
{
    public class CreateCustomerRequestEvent : IRequest<Customer>
    {
        public CreateCustomerRequestEvent(string name, DateTime birthdate, string email, Address address)
        {
            Name = name;
            Birthdate = birthdate;
            Email = email;
            Address = address;
        }

        public string Name { get; }
        public DateTime Birthdate { get; }
        public string Email { get; }
        public Address Address { get; }
    }
}
