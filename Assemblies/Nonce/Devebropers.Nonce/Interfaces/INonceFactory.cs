using System;

namespace Devebropers.Nonce
{
    /// <summary>
    /// A factory to create <see cref="INonce"/>
    /// </summary>
    public interface INonceFactory
    {
        /// <summary>
        /// Creates a new <see cref="INonce"/>
        /// </summary>
        /// <returns>The <see cref="INonce"/></returns>
        INonce CreateNonce();
        
        /// <summary>
        /// Gets a <see cref="INonce"/> by its token
        /// </summary>
        /// <param name="token">The token of the nonce</param>
        /// <returns>The <see cref="INonce"/></returns>
        /// <exception cref="ArgumentException"><paramref name="token"/></exception>
        INonce GetNonce(string token);
    }
}