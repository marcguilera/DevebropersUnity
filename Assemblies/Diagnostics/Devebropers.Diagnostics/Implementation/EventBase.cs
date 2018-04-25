using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Devebropers.Common;
namespace Devebropers.Diagnostics
{
    /// <summary>
    /// A base for all <see cref="IEvents"/>
    /// </summary>
    public abstract class EventBase : IEvent
    {
        public string Name { get; }
        private readonly IEventSender _eventSender;
        private readonly IDictionary<string, object> _arguments;
        
        /// <summary>
        /// Constructs a <see cref="EventBase"/>
        /// </summary>
        /// <param name="eventSender">The <see cref="IEventSender"/></param>
        /// <param name="name">The name of the event</param>
        /// <exception cref="AgumentNullException"><paramref name="eventSender"/></exception>
        /// <exception cref="ArgumentException"><paramref name="name"/></exception>
        protected EventBase(IEventSender eventSender, string name)
        {
            _eventSender = eventSender.AssignOrThrowIfNull(nameof(eventSender));
            Name = name.AssignOrThrowIfNullOrWhiteSpace(nameof(name));
            _arguments = new Dictionary<string, object>();
        }

        public void Send()
        {
            _eventSender.Send(Name, _arguments);
        }

        /// <summary>
        /// Adds an argument to this event
        /// </summary>
        /// <param name="name">The name of the event</param>
        /// <param name="argument"></param>
        /// <exception cref="ArgumentException"><paramref name="name"/></exception>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/></exception>
        protected void PutArgument(string name, object argument)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(nameof(name));
            }
            if (argument == null)
            {
                throw new ArgumentNullException(nameof(argument));
            }
            _arguments[name] = argument;
        }
    }
}
