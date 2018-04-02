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

        [Theory]
        [CompanyAddressValidData]
        public void UpdateItself(string country, string state, string town, string street,
            int buildingNumber, int flatNumber, string zipCode)
        {
            //Arrange
            var companyMock = Mock.Of<Company>(x => x.Id == 1);
            var sut = new CompanyAddress("Test Country", "Test State", "Test Town",
                "Test Street", 87, 8, "00-000", companyMock);

            //Act
            sut.Update(country, state, town, street, buildingNumber,
                flatNumber, zipCode);

            //Assert
            Assert.Equal(country, sut.Country);
            Assert.Equal(state, sut.State);
            Assert.Equal(town, sut.Town);
            Assert.Equal(street, sut.Street);
            Assert.Equal(buildingNumber, sut.BuildingNumber);
            Assert.Equal(flatNumber, sut.FlatNumber);
            Assert.Equal(zipCode, sut.ZipCode);
        }

        [Theory]
        [CompanyAddressNotValidData]
        public void ThrowsExceptionDuringUpdate(string country, string state, string town,
            string street, int buildingNumber, int flatNumber, string zipCode)
        {
            //Arrange
            var companyMock = Mock.Of<Company>(x => x.Id == 1);
            var sut = new CompanyAddress("Test Country", "Test State", "Test Town",
                "Test Street", 87, 8, "00-000", companyMock);

            //Act and Assert
            Assert.Throws<ForbiddenValueException>(() => sut.Update(country, state, town,
                street, buildingNumber, flatNumber, zipCode));
        }

        [Fact]
        public void DeleteItself()
        {
            //Arrange
            var companyMock = Mock.Of<Company>(x => x.Id == 1);
            var sut = new CompanyAddress("Test Country", "Test State", "Test Town",
                "Test Street", 87, 8, "00-000", companyMock);

            //Act
            sut.Delete();

            //Assert
            Assert.True(sut.Deleted);
        }
    }
}