namespace Devebropers.Data
{
    /// <summary>
    /// Constructs a <see cref="IIdentifier{TId}"/>
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    public abstract class IdentifierBase <TId> : IIdentifier<TId>
    {
        public TId Id { get; }

        protected IdentifierBase(TId id)
        {
            Id = id;
        }
    }
}