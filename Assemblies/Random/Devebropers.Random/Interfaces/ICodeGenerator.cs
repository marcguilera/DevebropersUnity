using System;

namespace Devebropers.Random
{
    /// <summary>
    /// Represents a code generator
    /// </summary>
    public interface ICodeGenerator
    {
        /// <summary>
        /// Generates a code of length <paramref name="length"/> and containing the characters <paramref name="chars"/>
        /// <see cref="Chars"/>
        /// </summary>
        /// <param name="chars">The allowed chars</param>
        /// <param name="length">The length of the code</param>
        /// <returns>The code</returns>
        /// <exception cref="ArgumentException">
        ///     <paramref name="chars"/> is null or empty
        ///     <paramref name="length"/> is not positive
        /// </exception>
        string Generate(string chars, int length);
        
        /// <summary>
        /// Uses a guid and the current time to generate a unique id
        /// </summary>
        /// <returns>The code</returns>
        string Generate();
    }
}