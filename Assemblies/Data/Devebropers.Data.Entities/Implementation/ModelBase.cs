using System;
using System.Data.Common;

namespace Devebropers.Data.Entities
{
    /// <summary>
    /// A model holding the data for an <see cref="IEntity{TId}"/>
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    public abstract class ModelBase <TId>
    {
        /// <summary>
        /// The Id of the <see cref="IEntity{TId}"/>
        /// </summary>
        public TId Id { get; set; }
        
        /// <summary>
        /// When the <see cref="IEntity{TId}"/> was first created
        /// </summary>
        public DateTime? Created { get; set; }
        
        /// <summary>
        /// When the <see cref="IEntity{TId}"/> was las updated
        /// </summary>
        public DateTime? Updated { get; set; }
    }
}