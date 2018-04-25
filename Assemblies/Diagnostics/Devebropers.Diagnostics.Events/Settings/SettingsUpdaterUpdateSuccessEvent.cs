using System.Runtime.InteropServices;

namespace Devebropers.Diagnostics.Events.Settings
{
    public class SettingsUpdaterUpdateSuccessEvent : EventBase
    {
        private const string _name = "Settings:Updater:Update_Success"; 
        public SettingsUpdaterUpdateSuccessEvent(IEventSender eventSender) 
            : base(eventSender, _name)
        {
        }
    }
}