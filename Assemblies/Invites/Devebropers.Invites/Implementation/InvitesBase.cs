using Devebropers.Common;
using Devebropers.Domains;
using Devebropers.Firebase.Invites;

namespace Devebropers.Invites
{
    internal abstract class InvitesBase : DomainObjectBase<InvitesDomainFactories>
    {
        protected readonly IFirebaseInvites _firebaseInvites;
        protected InvitesBase(InvitesDomainFactories domainFactories, IFirebaseInvites firebaseInvites) 
            : base(domainFactories)
        {
            _firebaseInvites = firebaseInvites.AssignOrThrowIfNull(nameof(firebaseInvites));
        }
    }
}