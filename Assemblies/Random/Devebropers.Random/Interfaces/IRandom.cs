namespace Devebropers.Random
{
    /// <summary>
    /// Generates random numbers
    /// </summary>
    public interface IRandom
    {
        /// <summary>
        /// Gets a random int
        /// </summary>
        /// <returns>The int</returns>
        int Get();
        
        /// <summary>
        /// Gets a random int between 0 and the <paramref name="limit"/>
        /// </summary>
        /// <param name="limit">Max int</param>
        /// <returns>The int</returns>
        int Get(int limit);
        
        /// <summary>
        /// Gets a random int between <paramref name="start"/> and <paramref name="limit"/>
        /// </summary>
        /// <param name="start">Minimum value</param>
        /// <param name="limit">Maximum value</param>
        /// <returns>The int</returns>
        int Get(int start, int limit);
    }
}