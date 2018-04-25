namespace Devebropers.Data
{
    /// <summary>
    /// Identifies a Entity
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    public interface IIdentifier <out TId>
    {
        
        /// <summary>
        /// The id for this entity
        /// </summary>
        TId Id { get; }
    }
}