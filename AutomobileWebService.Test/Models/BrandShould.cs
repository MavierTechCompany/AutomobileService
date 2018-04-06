using System;
using System.Collections.Generic;
using System.Text;
using AutomobileWebService.Business_Logic.Extras.Custom_Exceptions;
using AutomobileWebService.Business_Logic.Models;
using AutomobileWebService.Test.CustomAttributes;
using Xunit;

namespace AutomobileWebService.Test.Models
{
    public class BrandShould
    {
        [Theory]
        [BrandValidData]
        public void CreateItself(string name, DateTime startDate, DateTime? endDate)
        {
            //Arrange nad Act
            var sut = new Brand(name, startDate, endDate);

            //Assert
            Assert.Equal(name, sut.Name);
            Assert.Equal(startDate, sut.StartDate);
            Assert.Equal(endDate, sut.EndDate);
        }

        [Theory]
        [BrandNotValidData]
        public void ThrowsExceptionDuringCreation(string name, DateTime startDate, DateTime? endDate)
        {
            //Arrange, Act and Assert
            Assert.Throws<ForbiddenValueException>(() => new Brand(name, startDate, endDate));
        }

        [Theory]
        [BrandValidData]
        public void UpdateItself(string name, DateTime startDate, DateTime? endDate)
        {
            //Arrange
            Brand sut = new Brand("Brand", new DateTime(2000, 10, 5), null);

            //Act
            sut.Update(name, startDate, endDate);

            //Assert
            Assert.Equal(name, sut.Name);
            Assert.Equal(startDate, sut.StartDate);
            Assert.Equal(endDate, sut.EndDate);
        }

        [Theory]
        [BrandNotValidData]
        public void ThrowsExceptionDuringUpdate(string name, DateTime startDate, DateTime? endDate)
        {
            //Arrange
            Brand sut = new Brand("Brand", new DateTime(2000, 10, 5), null);

            //Act and Assert
            Assert.Throws<ForbiddenValueException>(() => sut.Update(name, startDate, endDate));
        }

        [Fact]
        public void DeleteItself()
        {
            //Arrange
            Brand sut = new Brand("Brand", new DateTime(2000, 10, 5), null);

            //Act
            sut.Delete();

            //Assert
            Assert.True(sut.Deleted);
        }
    }
}