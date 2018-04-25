using System;
using System.Collections.Generic;
using Devebropers.Validation;
using NUnit.Framework;

namespace Devebropers.Masking.Tests.Unit
{
    [TestFixture]
    public class EmailValidatorTests
    {
        const string _email = "test@gmail.com";
        
        #region IsValid

        [TestCaseSource(nameof(IsValidInvalidInputThrowsTestCases))]
        [Category("Validation"), Category("EmailValidator")]
        public void IsValid_InvalidInput_Throws(string email)
        {
            Assert.That(() => EmailValidator.IsValid(email), Throws.ArgumentException);
        }

        private static IEnumerable<TestCaseData> IsValidInvalidInputThrowsTestCases
        {
            get
            {
                yield return new TestCaseData(" ");
                yield return new TestCaseData("");
                yield return new TestCaseData(null);
            }
        }
        
        [TestCaseSource(nameof(IsValidInvalidEmailFalseTestCases))]
        [Category("Validation"), Category("EmailValidator")]
        public void IsValid_InvalidEmail_False(string email)
        {
            var isValid = EmailValidator.IsValid(email);
            Assert.That(isValid, Is.False);
        }

        private static IEnumerable<TestCaseData> IsValidInvalidEmailFalseTestCases
        {
            get
            {
                yield return new TestCaseData("invalid");
                yield return new TestCaseData("invalid@");
                yield return new TestCaseData("invalid@.");
                yield return new TestCaseData("invalid@gmail");
                yield return new TestCaseData("@gmail.com");
                yield return new TestCaseData("invalid@gmail.");
            }
        }
        
        [Test]
        [Category("Validation"), Category("EmailValidator")]
        public void IsValid_ValidEmail_True()
        {
            var isValid = EmailValidator.IsValid(_email);
            Assert.That(isValid, Is.True);
        }
        
        #endregion
    }
}