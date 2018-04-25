using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Devebropers.Masking.Tests.Unit
{
    [TestFixture]
    public class EmailMaskerTests
    {
        #region Mask

        [TestCaseSource(nameof(MaskInvalidInputThrowsTestCases))]
        [Category("Masking"), Category("EmailMasker")]
        public void Mask_InvalidInput_Throws(string email, char character, int startAt, Type exception)
        {
            Assert.That(() => EmailMasker.Mask(email, character, startAt), Throws.InstanceOf(exception));
        }

        private static IEnumerable<TestCaseData> MaskInvalidInputThrowsTestCases
        {
            get
            {
                var email = "test@gmail.com";
                var character = 'x';
                var startAt = 1;
                
                yield return new TestCaseData(" ", character, startAt, typeof(ArgumentException));
                yield return new TestCaseData("", character, startAt, typeof(ArgumentException));
                yield return new TestCaseData("invalid", character, startAt, typeof(FormatException));
                yield return new TestCaseData("invalid@", character, startAt, typeof(FormatException));
                yield return new TestCaseData("invalid@.", character, startAt, typeof(FormatException));
                yield return new TestCaseData("invalid@gmail", character, startAt, typeof(FormatException));
                yield return new TestCaseData("@gmail.com", character, startAt, typeof(FormatException));
                yield return new TestCaseData("invalid@gmail.", character, startAt, typeof(FormatException));
                yield return new TestCaseData(null, character, startAt, typeof(ArgumentException));
                yield return new TestCaseData(email, character, -1, typeof(ArgumentOutOfRangeException));
            }
        }
        
        [TestCaseSource(nameof(MaskValidInputReturnsTestCases))]
        [Category("Masking"), Category("EmailMasker")]
        public void Mask_InvalidInput_Throws(string email, char character, int startAt, string expected)
        {
            var maskedEmail = EmailMasker.Mask(email, character, startAt);
            Assert.That(maskedEmail, Is.EqualTo(expected));
        }

        private static IEnumerable<TestCaseData> MaskValidInputReturnsTestCases
        {
            get
            {
                var email = "test@gmail.com";
                yield return new TestCaseData(email, 'x', 1, "txxx@gmail.com");
                yield return new TestCaseData(email, 'x', 5, "test@gmail.com");
                yield return new TestCaseData("test@gmail.com", 'x', 0, "xxxx@gmail.com");
                yield return new TestCaseData(" test@gmail.com ", 'x', 0, "xxxx@gmail.com");
            }
        }

        #endregion
    }
}