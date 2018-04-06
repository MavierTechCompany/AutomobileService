using System;
using AutomobileWebService.Business_Logic.Extras.Custom_Exceptions;
using AutomobileWebService.Business_Logic.Models;
using AutomobileWebService.Test.CustomAttributes;
using Moq;
using Xunit;

namespace AutomobileWebService.Test.Models
{
    public class CompanyShould
    {
        [Theory]
        [CompanyValidData]
        public void CreateItself(string name, string phone)
        {
            //Arrange
            var addressMock = Mock.Of<CompanyAddress>(x => x.Id == 1);

            //Act
            var sut = new Company(name, phone, addressMock);

            //Assert
            Assert.Equal(name, sut.Name);
            Assert.Equal(phone, sut.Phone);
            Assert.Equal(addressMock.Id, sut.CompanyAddressId);
        }

        [Theory]
        [CompanyNotValidData]
        public void ThrowsExceptionDuringCreation(string name, string phone)
        {
            //Arrange
            var addressMock = Mock.Of<CompanyAddress>(x => x.Id == 1);

            //Act and Assert
            Assert.Throws<ForbiddenValueException>(() => new Company(name, phone, addressMock));
        }

        [Theory]
        [CompanyValidData]
        public void UpdateItself(string name, string phone)
        {
            //Arrange
            var addressMock = Mock.Of<CompanyAddress>(x => x.Id == 1);
            var sut = new Company("Test Copmany", "856951458", addressMock);

            //Act
            sut.Update(name, phone);

            //Assert
            Assert.Equal(name, sut.Name);
            Assert.Equal(phone, sut.Phone);
        }

        [Theory]
        [CompanyNotValidData]
        public void ThrowsExceptionDuringUpdate(string name, string phone)
        {
            //Arrange
            var addressMock = Mock.Of<CompanyAddress>(x => x.Id == 1);
            var sut = new Company("Test Copmany", "856951458", addressMock);

            //Act and Assert
            Assert.Throws<ForbiddenValueException>(() => sut.Update(name, phone));
        }

        [Fact]
        public void DeleteItself()
        {
            //Arrange
            var addressMock = Mock.Of<CompanyAddress>(x => x.Id == 1);
            var sut = new Company("Test Copmany", "856951458", addressMock);

            //Act
            sut.Delete();

            //Assert
            Assert.True(sut.Deleted);
        }
    }
}