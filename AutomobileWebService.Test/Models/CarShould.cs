using AutomobileWebService.Business_Logic.Extras.Custom_Exceptions;
using AutomobileWebService.Business_Logic.Models;
using AutomobileWebService.Test.CustomAttributes;
using Moq;
using System;
using Xunit;

namespace AutomobileWebService.Test.Models
{
    public class CarShould
    {

        [Theory]
        [CarValidData]
        public void CreateItself(string model, int horsepower, int generation, DateTime productionDate)
        {
            //Arrange
            var brandMock = Mock.Of<Brand>(x => x.Id == Guid.NewGuid() && x.Name == "Brand");
            var sutId = Guid.NewGuid();

            //Act
            Car sut = new Car(sutId, model, horsepower, generation, productionDate, brandMock);

            //Assert
            Assert.Equal(sutId, sut.Id);
            Assert.Equal(model, sut.Model);
            Assert.Equal(brandMock.Id, sut.BrandId);
            Assert.Equal(horsepower, sut.Horsepower);
            Assert.Equal(generation, sut.Generation);
            Assert.Equal(brandMock.Name, sut.BrandName);
            Assert.Equal(productionDate, sut.ProdutionDate);
        }

        [Theory]
        [CarNotValidData]
        public void ThrowsExceptionDuringCreation(string model, int horsepower, int generation, DateTime productionDate)
        {
            //Arrange
            var brandMock = Mock.Of<Brand>(x => x.Id == Guid.NewGuid() && x.Name == "Brand");

            //Act and Assert
            Assert.Throws<ForbiddenValueException>(() => new Car(Guid.NewGuid(),model, horsepower, generation, productionDate, brandMock));
        }

        [Theory]
        [CarValidData]
        public void UpdateItself(string model, int horsepower, int generation, DateTime productionDate)
        {
            //Arrange
            var brandMock = Mock.Of<Brand>(x => x.Id == Guid.NewGuid() && x.Name == "Brand");
            Car sut = new Car(Guid.NewGuid(), "Test", 90, 1, new DateTime(1950, 1, 1), brandMock);

            //Act
            sut.Update(model, horsepower, generation, productionDate);

            //Assert
            Assert.Equal(model, sut.Model);
            Assert.Equal(horsepower, sut.Horsepower);
            Assert.Equal(generation, sut.Generation);
            Assert.Equal(productionDate, sut.ProdutionDate);
        }

        [Theory]
        [CarNotValidData]
        public void ThrowsExceptionDuringUpdate(string model, int horsepower, int generation, DateTime productionDate)
        {
            //Arrange
            var brandMock = Mock.Of<Brand>(x => x.Id == Guid.NewGuid() && x.Name == "Brand");
            Car sut = new Car(Guid.NewGuid(), "Test", 90, 1, new DateTime(1950, 1, 1), brandMock);

            //Act and Assert
            Assert.Throws<ForbiddenValueException>(() => sut.Update(model, horsepower, generation, productionDate));
        }
    }
}