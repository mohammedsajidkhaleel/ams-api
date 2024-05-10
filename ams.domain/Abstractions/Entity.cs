using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ams.domain.Abstractions
{
    public abstract class Entity
    {
        private readonly List<IDomainEvent> _domainEvents = new();
        protected Entity(Guid id)
        {
            Id = id;
        }
        protected Entity() { }
        public Guid Id { get; init; }
        public bool IsDeleted { get; set; } 
        protected void RaiseDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
        protected void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
        protected IReadOnlyList<IDomainEvent> GetDomainEvents()
        {
            return _domainEvents;
        }
    }
}
