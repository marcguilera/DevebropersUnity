namespace Devebropers.Settings
{
    public static class SettingExtensions
    {
        /// <summary>
        /// Checks if the <see cref="ISettings"/> has a value
        /// </summary>
        /// <param name="setting">The <see cref="ISetting"/></param>
        /// <returns>True if the setting has a value, false otherwise</returns>
        public static bool HasValue(this ISetting setting)
        {
            return setting != null;
        }

        /// <summary>
        /// Gets the value of the <see cref="ISetting"/> if it has one or default
        /// </summary>
        /// <param name="setting">The <see cref="ISetting"/></param>
        /// <param name="defaultValue">The value</param>
        /// <returns>The value of the <see cref="ISetting"/> if exists or the default value otherwise</returns>
        public static string ValueOrDefault(this ISetting setting, string defaultValue)
        {
            return setting.HasValue() ? setting.StringValue : defaultValue;
        }
        
        /// <summary>
        /// Gets the value of the <see cref="ISetting"/> if it has one or default
        /// </summary>
        /// <param name="setting">The <see cref="ISetting"/></param>
        /// <param name="defaultValue">The value</param>
        /// <returns>The value of the <see cref="ISetting"/> if exists or the default value otherwise</returns>
        public static long ValueOrDefault(this ISetting setting, long defaultValue)
        {
            return setting.HasValue() ? setting.LongValue : defaultValue;
        }
        
        /// <summary>
        /// Gets the value of the <see cref="ISetting"/> if it has one or default
        /// </summary>
        /// <param name="setting">The <see cref="ISetting"/></param>
        /// <param name="defaultValue">The value</param>
        /// <returns>The value of the <see cref="ISetting"/> if exists or the default value otherwise</returns>
        public static double ValueOrDefault(this ISetting setting, double defaultValue)
        {
            return setting.HasValue() ? setting.DoubleValue : defaultValue;
        }
        
    }
}