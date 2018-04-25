using System;
using Devebropers.Domains;
using Devebropers.Firebase.Messaging;
using Devebropers.Messaging.Messages;
using Devebropers.Users;

namespace Devebropers.Messaging
{
    internal class MessageFactory : DomainObjectBase<MessagingDomainFactories>, IMessageFactory
    {
        public MessageFactory(MessagingDomainFactories domainFactories) 
            : base(domainFactories)
        {
        }

        public ISendableMessage Create(string id, IUserIdentifier to)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException(nameof(id));
            }

            if (to == null)
            {
                throw new ArgumentException(nameof(to));
            }
            
            return new SendableMessage(_domainFactories.MessageSender, id, to.Id);
        }
    }
}