using System;

namespace HomeSchool.Data.Repositories
{
    public abstract class EntityBase<T> : IEquatable<EntityBase<T>>, IEntityBase<T>
    {
        public T Id { get; set; }

        /// <summary>
        /// Returns always <c>True</c> if the Id field is equals to the Other Id field
        /// </summary>
        public bool Equals(EntityBase<T> other)
        {
            if (other == null)
            {
                return false;
            }

            return this.Id.Equals(other.Id);
        }
    }
}