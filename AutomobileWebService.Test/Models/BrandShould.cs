using AutomobileWebService.Business_Logic.Extras.Custom_Exceptions;
using AutomobileWebService.Business_Logic.Models;
using AutomobileWebService.Tests.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AutomobileWebService.Tests.Models
{
    public class BrandShould
    {
        [Theory]
        [BrandValidData]
        public void CreateItself(string name, DateTime startDate, DateTime? endDate)
        {
            //Arrange
            var sutId = Guid.NewGuid();

            //Act
            var sut = new Brand(sutId, name, startDate, endDate);

            //Assert
            Assert.Equal(sutId, sut.Id);
            Assert.Equal(name, sut.Name);
            Assert.Equal(startDate, sut.StartDate);
            Assert.Equal(endDate, sut.EndDate);
        }

        [Theory]
        [BrandNotValidData]
        public void ThrowsExceptionDuringCreation(string name, DateTime startDate, DateTime? endDate)
        {
            //Arrange, Act and Assert
            Assert.Throws<ForbiddenValueException>(() => new Brand(Guid.NewGuid(), name, startDate, endDate));
        }

        [Theory]
        [BrandValidData]
        public void UpdateItself(string name, DateTime startDate, DateTime? endDate)
        {
            //Arrange
            Brand sut = new Brand(Guid.NewGuid(), "Brand", new DateTime(2000, 10, 5), null);

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
            Brand sut = new Brand(Guid.NewGuid(), "Brand", new DateTime(2000, 10, 5), null);

            //Act and Assert
            Assert.Throws<ForbiddenValueException>(() => sut.Update(name, startDate, endDate));
        }
    }
}
