using System;

namespace Devebropers.Data.Entities
{
    /// <summary>
    /// A data entity
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    public interface IEntity <out TId> : IIdentifier<TId>, IResource
    {
        /// <summary>
        /// The time when the <see cref="IEntity{TId}"/> was first created/>
        /// </summary>
        DateTime? Created { get; }
    }
}