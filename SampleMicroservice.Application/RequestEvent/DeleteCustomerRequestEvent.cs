using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMicroservice.Application.RequestEvent
{
    public class DeleteCustomerRequestEvent : INotification
    {
        public DeleteCustomerRequestEvent(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
