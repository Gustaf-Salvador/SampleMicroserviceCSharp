using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleMicroservice.Domain.Model;

namespace SampleMicroservice.Application.RequestEvent
{
    public class GetCustomerByIdRequestEvent : IRequest<Customer>
    {
        public GetCustomerByIdRequestEvent(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
