namespace Devebropers.Authentication.Authenticators
{
    /// <summary>
    /// The kind of provider for a <see cref="IAuthenticator"/>
    /// </summary>
    public enum AuthenticationProvider
    {
        /// <summary>
        /// The session is anonymous
        /// </summary>
        Anonymous,
        
        /// <summary>
        /// The session is through email and password
        /// </summary>
        Email,
        
        /// <summary>
        /// The session is through Facebook
        /// </summary>
        Facebook,
        
        /// <summary>
        /// The session is through Google
        /// </summary>
        Google,
        
        /// <summary>
        /// The session is through Twitter
        /// </summary>
        Twitter,
        
        /// <summary>
        /// The session is through Github
        /// </summary>
        Github
    }
}