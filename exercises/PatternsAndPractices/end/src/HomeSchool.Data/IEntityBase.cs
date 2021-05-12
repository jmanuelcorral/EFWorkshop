using System;

namespace HomeSchool.Data.Repositories
{
    public interface IEntityBase<TKey> : IEquatable<EntityBase<TKey>>
    {
        TKey Id { get; set; }
    }
}