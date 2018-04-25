using System;
using System.Collections.Generic;

namespace Devebropers.Firebase.Analytics
{
    /// <summary>
    /// Represents Firebase Analytics
    /// </summary>
    public interface IFirebaseAnalytics
    {
        /// <summary>
        /// Logs an event
        /// </summary>
        /// <param name="name">The name of the event</param>
        /// <param name="arguments">A dictionary of arguments</param>
        /// <exception cref="ArgumentException"><paramref name="name"/></exception>
        /// <exception cref="ArgumentNullException"><paramref name="arguments"/></exception>
        void LogEvent(string name, IDictionary<string, object> arguments);
        
        /// <summary>
        /// Sets the Id of the current user
        /// </summary>
        /// <param name="id">The id</param>
        void SetUserId(string id);
    }
}