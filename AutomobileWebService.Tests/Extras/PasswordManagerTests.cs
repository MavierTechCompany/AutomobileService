using AutomobileWebService.Business_Logic.Extras;
using AutomobileWebService.Business_Logic.Models;
using NUnit.Framework;
using System;

namespace AutomobileWebService.Tests.Extras
{
    [TestFixture]
    class PasswordManagerTests
    {
        #region ValidationObjects

        static string[] validPasswords = { "qwertyuiop", "QWERTYUIOP", "QWERT1234", "123456789", "QWER.123456", "Qwer.1234", "Qaz.123,;4" };

        #endregion

        [Test]
        [TestCaseSource("validPasswords")]
        public void SecurePassword_ShouldPass(string value)
        {
            User testUser = new User(Guid.NewGuid(), "test1", "test1.test1@test1.com", "1234567890", value);

            string testPassword = PasswordManager.SecurePassword(value, testUser.Email, testUser.CreatedAt);

            Assert.AreEqual(testUser.HashedPassword, testPassword);
        }

        [Test]
        [TestCaseSource("validPasswords")]
        public void IsPasswordCorrect_ShouldPass(string value)
        {
            User testUser = new User(Guid.NewGuid(), "test1", "test1.test1@test1.com", "1234567890", value);

            bool isCorrect = PasswordManager.IsPasswordCorrect(testUser, value);

            Assert.IsTrue(isCorrect);
        }
    }
}
