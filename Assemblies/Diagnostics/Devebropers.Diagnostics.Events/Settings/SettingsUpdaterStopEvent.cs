namespace Devebropers.Diagnostics.Events.Settings
{
    public class SettingsUpdaterStopEvent : EventBase
    {
        private const string _name = "Settings:Updater:Stop";

        public SettingsUpdaterStopEvent(IEventSender eventSender) 
            : base(eventSender, _name)
        {
        }
    }
}