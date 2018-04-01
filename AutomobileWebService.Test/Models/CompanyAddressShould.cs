using System;
using AutomobileWebService.Business_Logic.Extras.Custom_Exceptions;
using AutomobileWebService.Business_Logic.Models;
using AutomobileWebService.Test.CustomAttributes;
using Moq;
using Xunit;

namespace AutomobileWebService.Test.Models
{
    public class CompanyAddressShould
    {
        [Theory]
        [CompanyAddressValidData]
        public void CreateItself(string country, string state, string town, string street,
            int buildingNumber, int flatNumber, string zipCode)
        {
            //Arrange
            var companyMock = Mock.Of<Company>(x => x.Id == 1);

            //Act
            var sut = new CompanyAddress(country, state, town, street, buildingNumber,
                flatNumber, zipCode, companyMock);

            //Assert
            Assert.Equal(country, sut.Country);
            Assert.Equal(state, sut.State);
            Assert.Equal(town, sut.Town);
            Assert.Equal(street, sut.Street);
            Assert.Equal(buildingNumber, sut.BuildingNumber);
            Assert.Equal(flatNumber, sut.FlatNumber);
            Assert.Equal(zipCode, sut.ZipCode);
            Assert.Equal(companyMock.Id, sut.CompanyId);
        }

        [Theory]
        [CompanyAddressNotValidData]
        public void ThrowsExceptionDuringCreation(string country, string state, string town,
            string street, int buildingNumber, int flatNumber, string zipCode)
        {
            //Arrange
            var companyMock = Mock.Of<Company>(x => x.Id == 1);

            //Act and Assert
            Assert.Throws<ForbiddenValueException>(() => new CompanyAddress(country, state,
                town, street, buildingNumber, flatNumber, zipCode, companyMock));
        }
    }
}