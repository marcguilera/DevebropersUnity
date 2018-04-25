using System;
using System.Collections.Generic;
using Devebropers.Common;
using Devebropers.Firebase.Analytics;
using Devebropers.Users;

namespace Devebropers.Diagnostics
{
    internal class EventSender : IEventSender
    {
        private readonly IFirebaseAnalytics _firebaseAnalytics;

        public EventSender(IFirebaseAnalytics firebaseAnalytics)
        {
            _firebaseAnalytics = firebaseAnalytics.AssignOrThrowIfNull(nameof(firebaseAnalytics));
        }

        public void Send(string name, IDictionary<string, object> arguments)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(nameof(name));
            }
            if (arguments == null)
            {
                throw new ArgumentNullException(nameof(arguments));
            }
            
            _firebaseAnalytics.LogEvent(name, arguments);
        }

        public void SetUser(IUserIdentifier user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            
            _firebaseAnalytics.SetUserId(user.Id);
        }
        
        public void RemoveUser() 
        {
            _firebaseAnalytics.SetUserId(null);
        }
    }
}
