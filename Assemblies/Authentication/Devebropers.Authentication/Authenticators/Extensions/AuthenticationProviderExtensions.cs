using System;
using System.Linq;

namespace Devebropers.Authentication.Authenticators
{
    public static class AuthenticationProviderExtensions
    {
        private static readonly AuthenticationProvider[] _socialProviders = 
        {
            AuthenticationProvider.Facebook, 
            AuthenticationProvider.Google, 
            AuthenticationProvider.Twitter,
            AuthenticationProvider.Github
        };
        
        /// <summary>
        /// Checks if the the <see cref="AuthenticationProvider"/> is Facebook, Google, Twitter or Github
        /// </summary>
        /// <param name="provider">The <see cref="AuthenticationProvider"/></param>
        /// <returns>True if the <see cref="AuthenticationProvider"/> is social, false otherwise</returns>
        public static bool IsSocial(this AuthenticationProvider provider)
        {
            return _socialProviders.Contains(provider);
        }
        
        /// <summary>
        /// Checks if the the <see cref="AuthenticationProvider"/> is anonymous
        /// </summary>
        /// <param name="provider">The <see cref="AuthenticationProvider"/></param>
        /// <returns>True if the <see cref="AuthenticationProvider"/> is anonymous, false otherwise</returns>
        public static bool IsAnonymous(this AuthenticationProvider provider)
        {
            return provider == AuthenticationProvider.Anonymous;
        }
        
        /// <summary>
        /// Checks if the the <see cref="AuthenticationProvider"/> is email
        /// </summary>
        /// <param name="provider">The <see cref="AuthenticationProvider"/></param>
        /// <returns>True if the <see cref="AuthenticationProvider"/> is email, false otherwise</returns>
        public static bool IsEmail(this AuthenticationProvider provider)
        {
            return provider == AuthenticationProvider.Email;
        }
    }
}