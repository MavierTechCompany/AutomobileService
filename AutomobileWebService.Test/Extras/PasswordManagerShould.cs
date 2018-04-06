using AutomobileWebService.Business_Logic.Extras;
using AutomobileWebService.Business_Logic.Models;
using AutomobileWebService.Test.CustomAttributes;
using System;
using Xunit;

namespace AutomobileWebService.Test.Extras
{
    public class PasswordManagerShould
    {
        [Theory]
        [SecurePasswordData]
        public void SecurePassword(string password, string email, DateTime createdAt)
        {
            string expected = PasswordManager.SecurePassword(password, email, createdAt);
            string sut = PasswordManager.SecurePassword(password, email, createdAt);

            Assert.Equal(expected, sut);
        }

        [Theory]
        [PasswordCheckData]
        public void CheckIfPasswordIsCorrect(User user, string password)
        {
            bool sut = PasswordManager.IsPasswordCorrect(user, password);

            Assert.True(sut);
        }
    }
}
