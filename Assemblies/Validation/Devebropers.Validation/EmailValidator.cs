using System;
using System.ComponentModel.DataAnnotations;

namespace Devebropers.Validation
{
    public static class EmailValidator
    {
        public static bool IsValid(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException(nameof(email));
            }
            
            return new EmailAddressAttribute().IsValid(email);
        }
    }
}
