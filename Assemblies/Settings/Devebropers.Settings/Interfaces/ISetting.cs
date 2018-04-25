namespace Devebropers.Settings
{
    /// <summary>
    /// Represents a setting
    /// </summary>
    public interface ISetting
    {
        /// <summary>
        /// The name of the setting
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// Gets the value of the setting as a string
        /// </summary>
        string StringValue { get; }
        
        /// <summary>
        /// Gets the value of the setting as a long
        /// </summary>
        long LongValue { get; }
        
        /// <summary>
        /// Gets the value of the setting as a double
        /// </summary>
        double DoubleValue { get; }
    }
}