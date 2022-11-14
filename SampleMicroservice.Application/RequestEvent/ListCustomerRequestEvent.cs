using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleMicroservice.Domain.Model;

namespace SampleMicroservice.Application.RequestEvent
{
    public class ListCustomerRequestEvent : IRequest<IEnumerable<Customer>>
    {
        public ListCustomerRequestEvent()
        {
        }

    }
}
