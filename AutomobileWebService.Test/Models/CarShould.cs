using AutomobileWebService.Business_Logic.Models;
using AutomobileWebService.Tests.CustomAttributes;
using Moq;
using System;
using Xunit;

namespace AutomobileWebService.Tests.Models
{
    public class CarShould
    {
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

        //[Theory]
        //public void ThrowExceptionWhileUpdating()
        //{
            
        //}
    }
}