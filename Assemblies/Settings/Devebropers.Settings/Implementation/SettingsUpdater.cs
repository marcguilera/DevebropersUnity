using System;
using System.Reactive;
using Devebropers.Common;
using Devebropers.Domains;
using Devebropers.Common.Utils;
using Devebropers.Firebase.Settings;

namespace Devebropers.Settings
{
    internal class SettingsUpdater : DomainObjectBase<SettingsDomainFactories>, ISettingsUpdater
    {
        public event OnUpdateStartEventHandler OnUpdateStart;
        public event OnUpdateStopEventHandler OnUpdateStop;
        public event OnUpdateAttemptEventHandler OnUpdateAttempt;
        public event OnUpdateSuccessEventHandler OnUpdateSuccess;
        public event OnUpdateErrorEventHandler OnUpdateError;

        private readonly Func<TimeSpan> _intervalGetter;
        private readonly IntervalTask _intervalTask;
        private readonly IFirebaseSettings _firebaseSettings;

        public SettingsUpdater(SettingsDomainFactories domainFactories, IFirebaseSettings firebaseSettings,
            Func<TimeSpan> intervalGetter)
            : base(domainFactories)
        {
            _firebaseSettings = firebaseSettings.AssignOrThrowIfNull(nameof(firebaseSettings));
            _intervalGetter = intervalGetter.AssignOrThrowIfNull(nameof(intervalGetter));
            _intervalTask = new IntervalTask(Update);
        }

        public void Start()
        {
            var interval = _intervalGetter();
            _intervalTask.Start(interval);
            InvokeOnUpdateStart(interval);
        }

        public void Stop()
        {
            _intervalTask.Dispose();
            InvokeOnUpdateStop();
        }

        private void Update()
        {
            InvokeOnUpdateAttempt();
            _firebaseSettings
                .Update()
                .Subscribe(InvokeOnUpdateSuccess, InvokeOnUpdateError);
        }

        private void InvokeOnUpdateSuccess(Unit unit)
        {
            OnUpdateSuccess?.Invoke();
        }

        private void InvokeOnUpdateError(Exception exception)
        {
            OnUpdateError?.Invoke(exception);
        }

        private void InvokeOnUpdateAttempt()
        {
            OnUpdateAttempt?.Invoke();
        }

        private void InvokeOnUpdateStop()
        {
            OnUpdateStop?.Invoke();
        }

        private void InvokeOnUpdateStart(TimeSpan interval)
        {
            OnUpdateStart?.Invoke(interval);
        }
        
    }
}