using System;
using Devebropers.Common;
using Devebropers.Diagnostics;
using Devebropers.Diagnostics.Events.Settings;

namespace Devebropers.Settings.Diagnostics
{
    public class SettingsUpdaterReporter : ReporterBase<ISettingsUpdater>
    {
        public SettingsUpdaterReporter(IEventSender eventSender, ISettingsUpdater settingsUpdater) 
            : base(eventSender, settingsUpdater)
        {
        }

        public override void StartReporting()
        {
            _target.OnUpdateAttempt += OnUpdateAttempt;
            _target.OnUpdateError += OnUpdateError;
            _target.OnUpdateSuccess += OnUpdateSuccess;
            _target.OnUpdateStart += OnUpdateStart;
            _target.OnUpdateStop += OnUpdateStop;
        }
        
        public override void StopReporting()
        {
            _target.OnUpdateAttempt -= OnUpdateAttempt;
            _target.OnUpdateError -= OnUpdateError;
            _target.OnUpdateSuccess -= OnUpdateSuccess;
            _target.OnUpdateStart -= OnUpdateStart;
            _target.OnUpdateStop -= OnUpdateStop;
        }

        private void OnUpdateStart(TimeSpan interval)
        {
            new SettingsUpdaterStartEvent(_eventSender, interval).Send();
        }
        
        private void OnUpdateStop()
        {
            new SettingsUpdaterStopEvent(_eventSender).Send();
        }

        private void OnUpdateAttempt()
        {
            new SettingsUpdaterUpdateAttemptEvent(_eventSender).Send();
        }
        
        private void OnUpdateSuccess()
        {
            new SettingsUpdaterUpdateSuccessEvent(_eventSender).Send();
        }

        private void OnUpdateError(Exception exception)
        {
            new SettingsUpdaterUpdateErrorEvent(_eventSender, exception).Send();
        }
    }
}