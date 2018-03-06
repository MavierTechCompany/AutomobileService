using AutomobileWebService.Business_Logic.Extras.Custom_Exceptions;
using AutomobileWebService.Business_Logic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileWebService.Business_Logic.Models
{
    public class Company : Entity
    {
        [Required]
        public string Name { get; protected set; }
        [Required]
        public string Phone { get; protected set; }
        [Required]
        public Guid CompanyAddressId { get; protected set; }

        public virtual CompanyAddress CompanyAddress { get; set; }

        protected Company()
        {

        }

        public Company(Guid id, string name, string phone, CompanyAddress headQuartersAddress)
        {
            Id = id;

            SetName(name);
            SetPhone(phone);

            CompanyAddressId = headQuartersAddress.Id;
        }

        #region Public

        public void Update(string name, DateTime foundationDate, string phone)
        {
            SetName(name);
            SetPhone(phone);
        }

        public static Company Delete(Company company)
        {
            company.Deleted = true;
            return company;
        }

        #endregion

        #region Private

        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ForbiddenValueException($"Company with id {Id} can not have an empty name.");
            }
            Name = name;
        }

        private void SetPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
                throw new ForbiddenValueException($"Company with id {Id} can not have an empty phone number.");
            }
            Phone = phone;
        }

        #endregion
    }
}
