using System;
using Devebropers.Domains;
using Devebropers.Firebase.Authentication;
using Devebropers.Users;
using Devebropers.Authentication.Authenticators;

namespace Devebropers.Authentication
{
    /// <summary>
    /// The <see cref="AuthenticationDomainFactories"/>
    /// </summary>
    public class AuthenticationDomainFactories : IDomainFactories
    {
        /// <summary>
        /// The <see cref="ISession"/>
        /// </summary>
        public virtual ISession Session { get; }
        
        /// <summary>
        /// The <see cref="IAnonymousAuthenticator"/>
        /// </summary>
        public virtual IAnonymousAuthenticator AnonymousAuthenticator { get; }
        
        /// <summary>
        /// The <see cref="IEmailAuthenticator"/>
        /// </summary>
        public virtual IEmailAuthenticator EmailAuthenticator { get; }
        
        /// <summary>
        /// The <see cref="IGoogleAuthenticator"/>
        /// </summary>
        public virtual IGoogleAuthenticator GoogleAuthenticator { get; }
        
        /// <summary>
        /// The <see cref="IFacebookAuthenticator"/>
        /// </summary>
        public virtual IFacebookAuthenticator FacebookAuthenticator { get; }
        
        /// <summary>
        /// The <see cref="ITwitterAuthenticator"/>
        /// </summary>
        public virtual ITwitterAuthenticator TwitterAuthenticator { get; }
        
        /// <summary>
        /// The <see cref="IGithubAuthenticator"/>
        /// </summary>
        public virtual IGithubAuthenticator GithubAuthenticator { get; }
        
        /// <summary>
        /// Constructs a <see cref="AuthenticationDomainFactories"/>
        /// </summary>
        /// <param name="firebaseAuthentication">The <see cref="IFirebaseAuthentication"/></param>
        /// <param name="userFactory">The <see cref="IUserFactory"/></param>
        /// <param name="eventSender">The <see cref="IEventSender"/></param>
        /// <param name="getters">The <see cref="IAuthentificationCredentialGetters"/></param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="firebaseAuthentication"/>
        ///     <paramref name="userFactory"/>
        ///     <paramref name="eventSender"/>
        ///     <paramref name="getters"/>
        /// </exception>
        public AuthenticationDomainFactories(IFirebaseAuthentication firebaseAuthentication, IUserFactory userFactory, 
            IAuthentificationCredentialGetters getters)
        {
            if (getters == null)
            {
                throw new ArgumentNullException(nameof(getters));
            }
            
            Session = new Session(this, firebaseAuthentication, userFactory);
            
            AnonymousAuthenticator = new AnonymousAuthenticator(this, firebaseAuthentication, userFactory);
            EmailAuthenticator = new EmailAuthenticator(this, firebaseAuthentication, userFactory);
            GoogleAuthenticator = new GoogleAuthenticator(this, firebaseAuthentication, userFactory, getters.GoogleIdTokenGetter, getters.GoogleAccessTokenGetter);
            FacebookAuthenticator = new FacebookAuthenticator(this, firebaseAuthentication, userFactory, getters.FacebookAccessTokenGetter);
            TwitterAuthenticator = new TwitterAuthenticator(this, firebaseAuthentication, userFactory, getters.TwitterAccessTokenGetter, getters.TwitterSecretGetter);
            GithubAuthenticator = new GithubAuthenticator(this, firebaseAuthentication, userFactory, getters.GithubAccessTokenGetter);
        }
    }
}
