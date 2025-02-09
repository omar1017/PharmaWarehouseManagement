using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Shared.Abstraction.Domain
{
    public abstract class AggregateRoot
    {
        public DateTime? CreatedAt { get; set; } 
        public DateTime? ModifiedAt { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; } = false;

        private readonly List<IDomainEvent> domainEvents = [];

        public List<IDomainEvent> DomainEvents => [.. domainEvents];

        public void ClearDomainEvents()
        {
            domainEvents.Clear(); 
        }

        public void Raise(IDomainEvent domainEvent)
        {
            domainEvents.Add(domainEvent);
        }
    }
}
