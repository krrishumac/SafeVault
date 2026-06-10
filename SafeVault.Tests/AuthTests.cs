using NUnit.Framework;
using SafeVault.Services;

namespace SafeVault.Tests
{
    public class AuthTests
    {
        private AuthService authService;

        [SetUp]
        public void Setup()
        {
            authService = new AuthService();
        }

        [Test]
        public void Valid_Admin_Login_Should_Succeed()
        {
            var user = authService.Authenticate(
                "admin",
                "Admin123");

            Assert.That(user, Is.Not.Null);
            Assert.That(user!.Role, Is.EqualTo("Admin"));
        }

        [Test]
        public void Invalid_Login_Should_Fail()
        {
            var user = authService.Authenticate(
                "admin",
                "WrongPassword");

            Assert.That(user, Is.Null);
        }

        [Test]
        public void Valid_User_Login_Should_Succeed()
        {
            var user = authService.Authenticate(
                "user",
                "User123");

            Assert.That(user, Is.Not.Null);
            Assert.That(user!.Role, Is.EqualTo("User"));
        }
    }
}