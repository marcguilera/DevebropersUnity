using Devebropers.Common;
using Firebase.Messaging;

namespace Devebropers.Messaging.Messages
{
    internal class SendableMessage : MessageBase, ISendableMessage
    {
        private readonly IMessageSender _sender;
        
        public SendableMessage(IMessageSender sender, string id, string to) 
            : base(new FirebaseMessage())
        {
            _sender = sender.AssignOrThrowIfNull(nameof(sender));
            _message.MessageId = id.AssignOrThrowIfNullOrWhiteSpace(nameof(id));
            _message.To = to.AssignOrThrowIfNullOrWhiteSpace(nameof(to));
        }

        public void Send()
        {
            _sender.Send(this);
        }
    }
}