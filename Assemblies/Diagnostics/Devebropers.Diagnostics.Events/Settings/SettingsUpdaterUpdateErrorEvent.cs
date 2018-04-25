using System;

namespace Devebropers.Diagnostics.Events.Settings
{
    public class SettingsUpdaterUpdateErrorEvent : ErrorEventBase
    {
        private const string _name = "Settings:Updater:Update_Error";
        
        public SettingsUpdaterUpdateErrorEvent(IEventSender eventSender, Exception exception) 
            : base(eventSender, _name, exception)
        {
        }
    }
}