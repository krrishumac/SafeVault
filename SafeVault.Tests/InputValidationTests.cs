using NUnit.Framework;
using SafeVault.Helpers;

namespace SafeVault.Tests
{
    public class InputValidationTests
    {
        [Test]
        public void TestForSQLInjection()
        {
            string attack = "' OR 1=1 --";

            string result =
                InputValidator.SanitizeInput(attack);

            Assert.That(result.Contains("'"), Is.False);
            Assert.That(result.Contains("--"), Is.False);
        }

        [Test]
        public void TestForXSS()
        {
            string attack =
                "<script>alert('hack')</script>";

            string result =
                InputValidator.SanitizeInput(attack);

            Assert.That(
                result.Contains("<script>"),
                Is.False);
        }
    }
}