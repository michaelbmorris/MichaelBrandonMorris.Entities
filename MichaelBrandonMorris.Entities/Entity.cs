using System;
using System.Collections.Generic;

namespace MichaelBrandonMorris.Entities
{
    public abstract class Entity<TId> : IEquatable<Entity<TId>>
    {
        protected Entity()
        {
            if (typeof(TId) != typeof(int) && 
                typeof(TId) != typeof(long) && 
                typeof(TId) != typeof(Guid) &&
                typeof(TId) != typeof(string))
            {
                throw new NotSupportedException($"Type {typeof(TId)} is not a supported type for the Id property.");
            }
        }

        public TId Id { get; set; }

        /// <inheritdoc />
        public bool Equals(Entity<TId> other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            return ReferenceEquals(this, other) || EqualityComparer<TId>.Default.Equals(Id, other.Id);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj.GetType() == this.GetType() && Equals((Entity<TId>) obj);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return EqualityComparer<TId>.Default.GetHashCode(Id);
        }

        public static bool operator ==(Entity<TId> left, Entity<TId> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Entity<TId> left, Entity<TId> right)
        {
            return !Equals(left, right);
        }
    }
}
