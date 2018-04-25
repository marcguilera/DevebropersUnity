namespace Devebropers.Nonce
{
    /// <summary>
    /// Represents an object which contains a token
    /// </summary>
    public interface ITokenable
    {
        /// <summary>
        /// The token
        /// </summary>
        string Token { get; }
    }
}