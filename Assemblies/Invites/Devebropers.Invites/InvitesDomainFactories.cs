using System;
using Devebropers.Domains;
using Devebropers.Firebase.Invites;

namespace Devebropers.Invites
{
    /// <summary>
    /// The invite domain
    /// </summary>
    public class InvitesDomainFactories : IDomainFactories
    {
        internal virtual IInviteSender InviteSender { get; }
        internal virtual IInviteConverter InviteConverter { get; }
        
        /// <summary>
        /// Gets an <see cref="IInviteFactory"/>
        /// </summary>
        public virtual IInviteFactory InviteFactory { get; }
        
        /// <summary>
        /// Constructs a <see cref="InvitesDomainFactories"/>
        /// </summary>
        /// <param name="firebaseInvites"><paramref name="firebaseInvites"/></param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="firebaseInvites"/>
        /// </exception>
        public InvitesDomainFactories(IFirebaseInvites firebaseInvites)
        {
            InviteSender = new InviteSender(this, firebaseInvites);
            InviteConverter = new InviteConverter(this, firebaseInvites);
            InviteFactory = new InviteFactory(this, firebaseInvites);
        }
    }
}