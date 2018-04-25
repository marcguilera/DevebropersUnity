using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Firebase.RemoteConfig;

namespace Devebropers.Firebase.Settings
{
    public class FirebaseSettings : IFirebaseSettings
    {
        public event OnUpdateSuccessEventHandler OnUpdateSuccess;
        public event OnUpdateErrorEventHandler OnUpdateError;

        public IObservable<Unit> Update()
        {
            var subject = new ReplaySubject<Unit>();
            
            FirebaseRemoteConfig
                .FetchAsync()
                .ContinueWith(task =>
                {
                    if (task.IsCanceled)
                    {
                        subject.OnError(new FirebaseSettingsException("Update was cancelled"));
                        return;
                    }

                    if (task.IsFaulted)
                    {
                        subject.OnError(new FirebaseSettingsException("Error updating", task.Exception));
                        return;
                    }
                    
                    FirebaseRemoteConfig.ActivateFetched();
                    subject.OnNext(new Unit());
                    subject.OnCompleted();
                });

            return subject.Do(x => OnUpdateSuccess?.Invoke(), e => OnUpdateError?.Invoke(e));
        }

        public ConfigValue GetValue(string name)
        {
            return FirebaseRemoteConfig.GetValue(name);
        }

        public void SetDefaults(IDictionary<string, object> defaultValues)
        {
            FirebaseRemoteConfig.SetDefaults(defaultValues);
        }
    }
}