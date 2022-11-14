using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleMicroservice.Domain.Model;

namespace SampleMicroservice.Domain.Events
{
    public class CustomerChangedDomainEvent : INotification
    {
        public CustomerChangedDomainEvent(Guid customerId, string changedField, object oldValue, object newValue)
        {
            CustomerId = customerId;
            ChangedField = changedField;
            OldValue = oldValue;
            NewValue = newValue;
            ModifiedDateUtc = DateTime.UtcNow;
        }

        public Guid CustomerId { get; set; }

        public string ChangedField { get; set; }

        public object OldValue { get; set; }

        public object NewValue { get; set; }

        public DateTime ModifiedDateUtc { get; set; }
    }
}
