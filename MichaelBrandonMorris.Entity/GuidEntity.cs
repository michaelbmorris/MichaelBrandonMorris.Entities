using System;

namespace MichaelBrandonMorris.Entity
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public abstract class GuidEntity : IEquatable<GuidEntity>
    {
        public Guid Id { get; set; }

        /// <inheritdoc />
        public bool Equals(GuidEntity other)
        {
            if (other is null)
            {
                return false;
            }

            return ReferenceEquals(this, other) || Id.Equals(other.Id);
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

            return obj.GetType() == GetType() && Equals((GuidEntity) obj);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            // ReSharper disable once NonReadonlyMemberInGetHashCode
            return Id.GetHashCode();
        }
    }
}
