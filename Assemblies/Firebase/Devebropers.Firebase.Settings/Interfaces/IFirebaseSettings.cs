using System;
using System.Collections.Generic;
using System.Reactive;
using Firebase.RemoteConfig;

namespace Devebropers.Firebase.Settings
{
    public delegate void OnUpdateSuccessEventHandler();
    public delegate void OnUpdateErrorEventHandler(Exception exception);
    
    /// <summary>
    /// Represents the Firebase settings system
    /// </summary>
    public interface IFirebaseSettings
    {
        event OnUpdateSuccessEventHandler OnUpdateSuccess;
        event OnUpdateErrorEventHandler OnUpdateError;
        
        /// <summary>
        /// Refreshes the remote settings
        /// </summary>
        /// <returns><see cref="Unit"/></returns>
        IObservable<Unit> Update();
        
        /// <summary>
        /// Gets the value of a setting by <paramref name="name"/>
        /// </summary>
        /// <param name="name">The name of the setting</param>
        /// <returns>A <see cref="ConfigValue"/></returns>
        ConfigValue GetValue(string name);
        
        /// <summary>
        /// Sets the default values
        /// </summary>
        /// <param name="defaultValues">A map of default values to set</param>
        void SetDefaults(IDictionary<string, object> defaultValues);
    }
}