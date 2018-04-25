using System;

namespace Devebropers.Data.Entities
{
    /// <summary>
    /// An <see cref="IEntity{TId}"/> that can be updated
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    public interface IUpdateableEntity <out TId> : IEntity<TId>, IUpdateableResource
    {
        /// <summary>
        /// The last time the <see cref="IUpdateableEntity{TId}"/> was updated
        /// </summary>
        DateTime? Updated { get; }
    }
}