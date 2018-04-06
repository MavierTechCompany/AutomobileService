using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomobileWebService.Business_Logic.Extras.Custom_Exceptions;
using AutomobileWebService.Business_Logic.Models;

namespace AutomobileWebService.Business_Logic.Models
{
    public class Company : Entity
    {
        public string Name { get; protected set; }
        public string Phone { get; protected set; }
        public int CompanyAddressId { get; protected set; }

        public virtual CompanyAddress CompanyAddress { get; set; }

        protected Company()
        {

        }

        public Company(string name, string phone,
            CompanyAddress headQuartersAddress) : base()
        {
            SetName(name);
            SetPhone(phone);

            CompanyAddressId = headQuartersAddress.Id;
        }

        #region Public

        public void Update(string name, string phone)
        {
            SetName(name);
            SetPhone(phone);
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