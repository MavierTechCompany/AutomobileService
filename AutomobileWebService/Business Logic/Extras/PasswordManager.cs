using AutomobileWebService.Business_Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileWebService.Business_Logic.Extras
{
    public static class PasswordManager
    {
        public static bool IsPasswordCorrect(User user, string password)
        {
            var securedPassword = SecurePassword(password, user.Email, user.CreatedAt);

            return securedPassword == user.HashedPassword;
        }

        public static string SecurePassword(string password, string email, DateTime createdAt)
        {
            var saltPassword = SaltPassword(email, createdAt);
            var hashPassword = HashPassword(saltPassword + password);

            return hashPassword;
        }

        private static string SaltPassword(string email, DateTime createdAt)
        {
            var createdAtChanged = createdAt.AddMonths(3).AddDays(4.5);
            var reverseDaysAndMounth = (createdAtChanged.Ticks.ToString().Reverse() + createdAtChanged.TimeOfDay.ToString()).ToString();
            var reverseLogin = email.Reverse();
            var salt = (createdAtChanged.Year.ToString() + reverseLogin + reverseDaysAndMounth).Remove(2, 1).Remove(5,3);

            return salt;
        }

        private static string HashPassword(string saltedPassword)
        {
            using (var sha256 = SHA256.Create())
            {
                // Send a sample password to hash.
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));

                // Get the hashed string.
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }
}
