using System;
using System.Collections.Generic;

namespace Devebropers.Settings
{
    /// <summary>
    /// Representa a factory settings
    /// </summary>
    public interface ISettingFactory
    {
        /// <summary>
        /// Sets the default values for this <see cref="ISettingFactory"/>
        /// </summary>
        /// <param name="defaultValues">A dictionary of default values</param>
        void SetDefaults(IReadOnlyDictionary<string, object> defaultValues);
        
        /// <summary>
        /// Gets a setting by its name
        /// </summary>
        /// <param name="name">The name of the setting</param>
        /// <returns>The setting if exists, null otherwise</returns>
        ISetting Get(string name);
    }
}