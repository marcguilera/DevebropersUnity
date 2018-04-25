using System;
using Devebropers.Validation;

namespace Devebropers.Masking
{
    public static class EmailMasker
    {
        public static string Mask(string email, char character = '*', int startAt = 1)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException(nameof(email));
            }
            if (startAt < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startAt));
            }

            email = email.Trim();

            var isValid = EmailValidator.IsValid(email);

            if (!isValid)
            {
                throw new FormatException(nameof(email) + "is not a valid email");
            }

            var atIndex = email.IndexOf('@');
            var result = email.ToCharArray();
            
            for (var i = startAt; i < atIndex; i++)
            {
                result[i] = character;
            }
            
            return new string(result);
        }
    }
}
