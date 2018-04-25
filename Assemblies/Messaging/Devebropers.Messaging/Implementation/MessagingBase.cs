using Devebropers.Common;
using Devebropers.Domains;
using Devebropers.Firebase.Messaging;

namespace Devebropers.Messaging
{
    internal class MessagingBase : DomainObjectBase<MessagingDomainFactories>
    {
        protected readonly IFirebaseMessaging _firebaseMessaging;
        public MessagingBase(MessagingDomainFactories domainFactories, IFirebaseMessaging firebaseMessaging) 
            : base(domainFactories)
        {
            _firebaseMessaging = firebaseMessaging.AssignOrThrowIfNull(nameof(firebaseMessaging));
        }
    }
}