using System;

namespace MichaelBrandonMorris.Entity
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public abstract class LongEntity : IEquatable<LongEntity>
    {
        public long Id { get; set; }

        /// <inheritdoc />
        public bool Equals(LongEntity other)
        {
            if (other is null)
            {
                return false;
            }

            return ReferenceEquals(this, other) || Id == other.Id;
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

            return obj.GetType() == GetType() && Equals((LongEntity) obj);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            // ReSharper disable once NonReadonlyMemberInGetHashCode
            return Id.GetHashCode();
        }
    }
}
