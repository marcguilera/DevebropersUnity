using System;

namespace Devebropers.Authentication.Authenticators
{
    /// <summary>
    /// Getters to be used by the <see cref="ISocialAuthenticator"/>s to get the tokens.
    /// </summary>
    public interface IAuthentificationCredentialGetters
    {
        Func<string> GoogleIdTokenGetter { get; }
        Func<string> GoogleAccessTokenGetter { get; }

        Func<string> FacebookAccessTokenGetter { get; }
        
        Func<string> TwitterAccessTokenGetter { get; }
        Func<string> TwitterSecretGetter { get; }
        
        Func<string> GithubAccessTokenGetter { get; }
    }
}