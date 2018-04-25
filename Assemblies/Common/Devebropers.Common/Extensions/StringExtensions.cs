using System;

namespace Devebropers.Common.Extensions
{
    public static class StringExtensions
    {
        public static Uri ToUri(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                throw new ArgumentNullException(nameof(str));
            }
            return new Uri(str);
        }
        
    }
}