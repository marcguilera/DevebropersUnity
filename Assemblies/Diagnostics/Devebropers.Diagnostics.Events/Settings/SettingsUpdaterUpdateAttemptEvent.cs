namespace Devebropers.Diagnostics.Events.Settings
{
    public class SettingsUpdaterUpdateAttemptEvent : EventBase
    {
        private const string _name = "Settings:Updater:Update_Attempt";
        public SettingsUpdaterUpdateAttemptEvent(IEventSender eventSender) 
            : base(eventSender, _name)
        {
        }
    }
}