namespace Devebropers.Storage
{
    /// <summary>
    /// Persists objects
    /// </summary>
    public interface IObjectPersister
    {
        /// <summary>
        /// Loads an object from a path
        /// </summary>
        /// <param name="path">The path of the object</param>
        /// <typeparam name="T"></typeparam>
        /// <returns>The object</returns>
        T Load<T>(string path);
        
        /// <summary>
        /// Writes the object to a path
        /// </summary>
        /// <param name="path">The path to write the object to</param>
        /// <param name="obj">The object to write</param>
        /// <typeparam name="T"></typeparam>
        void Write<T>(string path, T obj);

        /// <summary>
        /// Checks if the file exists
        /// </summary>
        /// <param name="path">The path of the file</param>
        /// <returns>True if the file exists</returns>
        bool Exists(string path);
    }
}