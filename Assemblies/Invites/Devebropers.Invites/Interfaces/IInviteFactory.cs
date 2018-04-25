using System;

namespace Devebropers.Invites
{
    /// <summary>
    /// A factory of <see cref="IInvite"/>
    /// </summary>
    public interface IInviteFactory
    {
        IObservable<IReceivedInvite> ReceivedInvites { get; }
        ISendableInvite CreateInvite(string titleText, string messageText, string callToActionText, Uri callToActionUrl);
    }
}