using AutomobileWebService.Business_Logic.Extras.Custom_Exceptions;
using AutomobileWebService.Business_Logic.Models;
using NUnit.Framework;
using System;

namespace AutomobileWebService.Tests.Models
{
    [TestFixture]
    class UserTests
    {
        #region ValidationObjects

        public static string[] validLogins =
        {
            "Test_123",
            "AnAsTaZjA_AnTkIeWiCz-285"
        };

        public static string[] notValidStrings =
        {
            null,
            "",
            " ",
            "   "
        };

        public static string[] validMobilePhones =
        {
            "758493210",
            "147506295"
        };

        #endregion

        [Test]
        [TestCaseSource("validLogins")]
        public void UpdateLogin_ShouldPass(string value)
        {
            User testUser = new User(Guid.NewGuid(), "testUser", "test.User@test.com", "123456789", "123ABC974");

            testUser.Update(value, testUser.MobilePhone);

            Assert.AreEqual(value, testUser.Login);
        }

        [Test]
        [TestCaseSource("notValidStrings")]
        public void UpdateLogin_ThrowException(string value)
        {
            User testUser = new User(Guid.NewGuid(), "testUser", "test.User@test.com", "123456789", "123ABC974");

            TestDelegate action = () => testUser.Update(value, testUser.MobilePhone);

            Assert.Throws<ForbiddenValueException>(action);
        }

        [Test]
        [TestCaseSource("validMobilePhones")]
        public void UpdateMobilePhone_ShouldPass(string value)
        {
            User testUser = new User(Guid.NewGuid(), "testUser", "test.User@test.com", "123456789", "123ABC974");

            testUser.Update(testUser.Login, value);

            Assert.AreEqual(value, testUser.MobilePhone);
        }

        [Test]
        [TestCaseSource("notValidStrings")]
        public void UpdateMobilePhone_ThrowException(string value)
        {
            User testUser = new User(Guid.NewGuid(), "testUser", "test.User@test.com", "123456789", "123ABC974");

            TestDelegate action = () => testUser.Update(testUser.Login, value);

            Assert.Throws<ForbiddenValueException>(action);
        }
    }
}
