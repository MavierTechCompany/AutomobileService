using AutomobileWebService.Business_Logic.Extras.Custom_Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileWebService.Business_Logic.Models
{
    public class CompanyAddress : Entity
    {
        [Required]
        public string Country { get; protected set; }
        [Required]
        public string State { get; protected set; }
        [Required]
        public string Town { get; protected set; }
        [Required]
        public string Street { get; protected set; }
        [Required]
        public int BuildingNumber { get; protected set; }
        [Required]
        public int FlatNumber { get; protected set; }
        [Required]
        public string ZipCode { get; protected set; }
        [Required]
        public Guid CompanyId { get; protected set; }

        public virtual Company Company { get; set; }


        protected CompanyAddress()
        {

        }

        public CompanyAddress(Guid id, string country, string state, string town, string street, int buildingNumber,
            int flatNumber, string zipCode, Company company) : base()
        {
            Id = id;
            CompanyId = company.Id;

            SetCountry(country);
            SetState(state);
            SetTown(town);
            SetStreet(street);
            SetBuildingNumber(buildingNumber);
            SetFlatNumber(flatNumber);
            SetZipCode(zipCode);
        }

        public void Update(string country, string state, string town, string street, int buildingNumber,
            int flatNumber, string zipCode)
        {
            SetCountry(country);
            SetState(state);
            SetTown(town);
            SetStreet(street);
            SetBuildingNumber(buildingNumber);
            SetFlatNumber(flatNumber);
            SetZipCode(zipCode);
        }

        public static CompanyAddress Delete(CompanyAddress address)
        {
            address.Deleted = true;
            return address;
        }

        private void SetCountry(string country)
        {
            if (string.IsNullOrWhiteSpace(country))
            {
                throw new ForbiddenValueException($"Address with id {Id} can not have an empty country");
            }
            Country = country;
        }

        private void SetState(string state)
        {
            if (string.IsNullOrWhiteSpace(state))
            {
                throw new ForbiddenValueException($"Address with id {Id} can not have an empty state");
            }
            State = state;
        }

        private void SetTown(string town)
        {
            if (string.IsNullOrWhiteSpace(town))
            {
                throw new ForbiddenValueException($"Address with id {Id} can not have an empty town.");
            }
            Town = town;
        }

        private void SetStreet(string street)
        {
            if (string.IsNullOrWhiteSpace(street))
            {
                throw new ForbiddenValueException($"Address with id {Id} can not have an empty street.");
            }
            Street = street;
        }

        private void SetBuildingNumber(int buildingNumber)
        {
            if (buildingNumber <= 0)
            {
                throw new ForbiddenValueException($"Address with id {Id} can not have building number less than one.");
            }
            BuildingNumber = buildingNumber;
        }

        private void SetFlatNumber(int flatNumber)
        {
            if (flatNumber <= 0)
            {
                throw new ForbiddenValueException($"Address with id {Id} can not have flat number less than one.");
            }
            FlatNumber = flatNumber;
        }

        private void SetZipCode(string zipCode)
        {
            if (string.IsNullOrWhiteSpace(zipCode))
            {
                throw new ForbiddenValueException($"Address with id {Id} can not have an zip code.");
            }
            ZipCode = zipCode;
        }
    }
}
