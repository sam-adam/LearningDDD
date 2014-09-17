namespace CarWash.Domain
{
    /// <summary>
    /// Interface for Domain Event Handlers
    /// </summary>
    /// <typeparam name="TDomainEvent">Domain event to handle</typeparam>
    public interface IDomainEventHandler<in TDomainEvent> where TDomainEvent : IDomainEvent
    {
        /// <summary>
        /// Handles a given event
        /// </summary>
        /// <param name="evt"></param>
        void Handles(TDomainEvent evt);
    }
}