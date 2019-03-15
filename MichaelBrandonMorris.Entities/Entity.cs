using System;
using System.Collections.Generic;

namespace MichaelBrandonMorris.Entities
{
    public abstract class Entity<TId> : IEquatable<Entity<TId>>
    {
        public TId Id { get; set; }

        /// <inheritdoc />
        public bool Equals(Entity<TId> other)
        {
            if (other is null)
            {
                return false;
            }

            return ReferenceEquals(this, other) || EqualityComparer<TId>.Default.Equals(Id, other.Id);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj.GetType() == GetType() && Equals((Entity<TId>) obj);
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
