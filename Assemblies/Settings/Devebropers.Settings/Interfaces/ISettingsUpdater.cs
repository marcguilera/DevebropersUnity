using System;

namespace Devebropers.Settings
{
    public delegate void OnUpdateStartEventHandler(TimeSpan interval);
    public delegate void OnUpdateStopEventHandler();
    public delegate void OnUpdateAttemptEventHandler();
    public delegate void OnUpdateSuccessEventHandler();
    public delegate void OnUpdateErrorEventHandler(Exception exception);
    
    /// <summary>
    /// Represents a setting updater
    /// </summary>
    public interface ISettingsUpdater
    {
        event OnUpdateStartEventHandler OnUpdateStart;
        event OnUpdateStopEventHandler OnUpdateStop;
        event OnUpdateAttemptEventHandler OnUpdateAttempt;
        event OnUpdateSuccessEventHandler OnUpdateSuccess;
        event OnUpdateErrorEventHandler OnUpdateError;
        
        /// <summary>
        /// Starts the update process
        /// </summary>
        void Start();
        
        /// <summary>
        /// Stops the update process
        /// </summary>
        void Stop();
    }
}