using System;

namespace Devebropers.Diagnostics.Events.Settings
{
    public class SettingsUpdaterStartEvent : EventBase
    {
        private const string _name = "Settings:Updater:Start";
        public SettingsUpdaterStartEvent(IEventSender eventSender, TimeSpan timeSpan) 
            : base(eventSender, _name)
        {
            PutArgument("seconds", timeSpan.Seconds);
        }
    }
}