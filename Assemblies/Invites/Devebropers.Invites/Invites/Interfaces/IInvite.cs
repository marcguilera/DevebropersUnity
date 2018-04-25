using System;
using System.Collections.Generic;
using System.Reactive;

namespace Devebropers.Invites
{
    /// <summary>
    /// Represents an invite
    /// </summary>
    public interface IInvite
    {
        /// <summary>
        /// The title of the invitation
        /// </summary>
        string TitleText { get; }
        
        /// <summary>
        /// The message text of the invitation
        /// </summary>
        string MessageText { get; }
        
        /// <summary>
        /// The call to action text of the invitation
        /// </summary>
        string CallToActionText { get; }
        
        /// <summary>
        /// The call to action url
        /// </summary>
        Uri CallToActionUrl { get; }
        
        /// <summary>
        /// The referral parameters
        /// </summary>
        IDictionary<string, string> ReferralParams { get; }
    }
}