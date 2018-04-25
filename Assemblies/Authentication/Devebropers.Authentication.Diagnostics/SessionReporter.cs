using System;
using Devebropers.Diagnostics;
using Devebropers.Diagnostics.Events.Authentication;
using Devebropers.Users;

namespace Devebropers.Authentication.Diagnostics
{
    /// <summary>
    /// Represents a <see cref="ISession"/> <see cref="IReporter"/>
    /// </summary>
    public class SessionReporter : ReporterBase<ISession>
    {
        public SessionReporter(IEventSender eventSender, ISession session) 
            : base(eventSender, session)
        {
        }

        public override void StartReporting()
        {
            _target.OnSignOut += OnSignOut;
        }
        
        public override void StopReporting()
        {
            _target.OnSignOut -= OnSignOut;
        }
        
        private void OnSignOut(IUserIdentifier user)
        {
            new SignOutEvent(_eventSender, user.Id).Send();
        }
    }
}