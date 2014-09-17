using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CarWash.Domain
{
    /// <summary>
    /// Base class for all entity type
    /// </summary>
    /// <typeparam name="TId">The type of this entity's id</typeparam>
    public abstract class Entity<TId>
    {
        private readonly DateTime _createdOn;
        private readonly DateTime _updatedOn;
        private readonly ICollection<IDomainEvent> _events;
        private EntityStatus _status;

        protected Entity()
        {
            _createdOn = DateTime.Now;
            _updatedOn = DateTime.Now;
            _events = new Collection<IDomainEvent>();
            _status = EntityStatus.Active;
        }

        /// <summary>
        /// Entity's unique id
        /// </summary>
        public virtual TId Id { get; set; }

        /// <summary>
        /// Entity's human readable code
        /// </summary>
        public virtual String Code { get; set; }

        /// <summary>
        /// Entity's creation timestamp
        /// </summary>
        public virtual DateTime CreatedOn { get { return _createdOn; } }

        /// <summary>
        /// Entity's last update timestamp
        /// </summary>
        public virtual DateTime UpdatedOn { get { return _updatedOn; } }

        /// <summary>
        /// Entity's status
        /// </summary>
        public virtual EntityStatus Status { get { return _status; } }

        /// <summary>
        /// Domain events to be raised
        /// </summary>
        public ICollection<IDomainEvent> Events { get { return _events; } }

        /// <summary>
        /// Mark this entity as removed
        /// </summary>
        /// <returns>Entity</returns>
        public Entity<TId> MarkAsRemoved()
        {
            _status = EntityStatus.Archived;

            return this;
        }

        /// <summary>
        /// Check if this entity is not persisted
        /// </summary>
        /// <returns></returns>
        public bool IsTransient()
        {
            return Equals(Id, default(TId));
        }

        /// <summary>
        /// Get entity's hash code
        /// </summary>
        /// <returns>
        /// Type's hash code if this entity is transient,
        /// otherwise returns the id's hashcode
        /// </returns>
        public override int GetHashCode()
        {
            return IsTransient() ? GetType().GetHashCode() : Id.GetHashCode();
        }

        /// <summary>
        /// Indicates whether the current entity
        /// is equals to another entity
        /// </summary>
        /// <param name="obj">An entity to compare with the this entity</param>
        /// <returns>
        /// True if the current object is equal
        /// to the <paramref name="obj"/> parameter;
        /// otherwise, false.
        /// </returns>
        public override bool Equals(object obj)
        {
            var entity = obj as Entity<TId>;

            if (entity == null)
                return false;

            if (IsTransient() && entity.IsTransient())
                return ReferenceEquals(this, entity);

            return Id.Equals(entity.Id);
        }

        /// <summary>
        /// Equal operator
        /// </summary>
        /// <param name="left">Left side entity to compare</param>
        /// <param name="right">Right side entity to compare</param>
        /// <returns>True if the entities are equal, otherwise false</returns>
        public static bool operator ==(Entity<TId> left, Entity<TId> right)
        {
            return Equals(left, null) ? Equals(right, null) : left.Equals(right);
        }

        /// <summary>
        /// Not equal operator
        /// </summary>
        /// <param name="left">Left side entity to compare</param>
        /// <param name="right">Right side entity to compare</param>
        /// <returns>True if the entities are unequal, otherwise false</returns>
        public static bool operator !=(Entity<TId> left, Entity<TId> right)
        {
            return !(left == right);
        }
    }
}