using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleMicroservice.Domain.Model;

namespace SampleMicroservice.Application.RequestEvent
{
    public class UpdateCustomerRequestEvent : IRequest<Customer>
    {
        public UpdateCustomerRequestEvent(Guid id, JsonPatchDocument<Customer> customerPatch)
        {
            Id = id;
            CustomerPatch = customerPatch;
        }

        public Guid Id { get; }

        public JsonPatchDocument<Customer> CustomerPatch { get; }
    }
}
