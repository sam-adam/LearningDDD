using System.Collections.Generic;

namespace CarWash.Domain
{
    public static class DomainEventManager
    {
        private static ICollection<IDomainEventHandler<TDomainEvent>> _events;

        public static void RegisterHandler<TDomainEvent>(IDomainEventHandler<TDomainEvent> handler) where TDomainEvent : IDomainEvent
        {
            
        }
    }
}