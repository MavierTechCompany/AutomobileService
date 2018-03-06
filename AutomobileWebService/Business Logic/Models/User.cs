using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutomobileWebService.Business_Logic.Extras;
using AutomobileWebService.Business_Logic.Extras.Custom_Exceptions;

namespace AutomobileWebService.Business_Logic.Models
{
    public class User : Entity
    {
        [Required]
        public string Login { get; protected set; }
        [Required]
        public string Email { get; protected set; }
        [Required]
        public string MobilePhone { get; protected set; }
        [Required]
        public string HashedPassword { get; protected set; }
        [Required]
        public DateTime CreatedAt { get; protected set; }

        public virtual List<Project> Projects { get; set; }
        public virtual List<Comment> Comments { get; set; }

        protected User()
        {

        }

        public User(Guid id, string login, string email, string mobilePhone, string password)
        {
            Id = id;
            CreatedAt = DateTime.UtcNow;

            SetLogin(login);
            SetEmail(email);
            SetMobilePhone(mobilePhone);
            SetPassword(password);

        }

        #region Public

        public void Update(string login, string mobilePhone)
        {
            SetLogin(login);
            SetMobilePhone(mobilePhone);
        }

        public void UpdatePassword(string password)
        {
            SetPassword(password);
        }

        public static User Delete(User user)
        {
            user.Deleted = true;
            return user;
        }

        #endregion

        #region Private

        private void SetLogin(string login)
        {
            if (string.IsNullOrWhiteSpace(login))
            {
                throw new ForbiddenValueException($"User with id: {Id} can't have a empty login.");
            }

            Login = login;
        }

        private void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ForbiddenValueException($"User with id: {Id} can't have a empty email.");
            }

            Email = email;
        }

        private void SetMobilePhone(string mobilePhone)
        {
            if (string.IsNullOrWhiteSpace(mobilePhone))
            {
                throw new ForbiddenValueException($"User with id: {Id} can't have an empty number");
            }

            MobilePhone = mobilePhone;
        }

        private void SetPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ForbiddenValueException($"User with id: {Id} can't have an empty password");
            }

            HashedPassword = PasswordManager.SecurePassword(password, Email, CreatedAt);
        }

        #endregion
    }
}
