using System.Collections.Generic;
using System.Linq;

namespace Devebropers.Firebase.Analytics
{
    internal class FirebaseAnalytics : IFirebaseAnalytics
    {

        public void LogEvent(string name, IDictionary<string, object> arguments)
        {
            var parameters = arguments.Select(x => GetParameter(x.Key, x.Value)).ToArray();
            global::Firebase.Analytics.FirebaseAnalytics.LogEvent(name, parameters);
        }

        public void SetUserId(string id)
        {
            global::Firebase.Analytics.FirebaseAnalytics.SetUserId(id);
        }

        private global::Firebase.Analytics.Parameter GetParameter(string id, object value)
        {
            
            if (value is long || value is int)
            {
                return new global::Firebase.Analytics.Parameter(id, (long) value);
            }
            
            if (value is float || value is double)
            {
                return new global::Firebase.Analytics.Parameter(id, (double) value);
            }
            
            return new global::Firebase.Analytics.Parameter(id, value.ToString());
        }
    }
}