using AutomobileWebService.Business_Logic.Extras.Custom_Exceptions;
using AutomobileWebService.Business_Logic.Models;
using AutomobileWebService.Test.CustomAttributes;
using Moq;
using System;
using Xunit;

namespace AutomobileWebService.Test.Models
{
    public class ProjectShould
    {
        [Theory]
        [ProjectValidData]
        public void CreateItself(string projectName, string category, int horsepower,
            float topSpeedInKilometers, float topSpeedInMiles, float zeroToHundreds,
            string engineModel, bool hasTurbocharger, bool hasSupercharger)
        {
            //Arrange
            var carMock = Mock.Of<Car>(x => x.Id == 1);
            var userMock = Mock.Of<User>(x => x.Id == 1);

            //Act
            var sut = new Project(projectName, category, horsepower, topSpeedInKilometers,
                topSpeedInMiles, zeroToHundreds, engineModel, hasTurbocharger, hasSupercharger,
                carMock, userMock);

            //Assert
            Assert.Equal(projectName, sut.ProjectName);
            Assert.Equal(category, sut.Category);
            Assert.Equal(horsepower, sut.Horsepower);
            Assert.Equal(topSpeedInKilometers, sut.TopSpeedInKilometers);
            Assert.Equal(topSpeedInMiles, sut.TopSpeedInMiles);
            Assert.Equal(zeroToHundreds, sut.ZeroToHundreds);
            Assert.Equal(engineModel, sut.EngineModel);
            Assert.Equal(hasTurbocharger, sut.HasSupercharger);
            Assert.Equal(hasSupercharger, sut.HasSupercharger);        
        }

        [Theory]
        [ProjectNotValidData]
        public void ThrowsExceptionDuringCreation(string projectName, string category, int horsepower,
            float topSpeedInKilometers, float topSpeedInMiles, float zeroToHundreds,
            string engineModel, bool hasTurbocharger, bool hasSupercharger)
        {
            //Arrange
            var carMock = Mock.Of<Car>(x => x.Id == 1);
            var userMock = Mock.Of<User>(x => x.Id == 1);

            Assert.Throws<ForbiddenValueException>(() => new Project(projectName, category,
                horsepower, topSpeedInKilometers, topSpeedInMiles, zeroToHundreds,
                engineModel, hasTurbocharger, hasSupercharger, carMock, userMock));
        }

        [Theory]
        [ProjectValidData]
        public void UpdateItself(string projectName, string category, int horsepower,
            float topSpeedInKilometers, float topSpeedInMiles, float zeroToHundreds,
            string engineModel, bool hasTurbocharger, bool hasSupercharger)
        {
            //Arrange
            var carMock = Mock.Of<Car>(x => x.Id == 1);
            var userMock = Mock.Of<User>(x => x.Id == 1);
            var sut = new Project("projectName", "category", 1, 1.0f, 1.0f, 1.0f,
            "engineModel", false, false, carMock, userMock);

            //Act
            sut.Update(projectName, category, horsepower, topSpeedInKilometers, topSpeedInMiles,
            zeroToHundreds, engineModel, hasTurbocharger, hasSupercharger);

            //Assert
            Assert.Equal(projectName, sut.ProjectName);
            Assert.Equal(category, sut.Category);
            Assert.Equal(horsepower, sut.Horsepower);
            Assert.Equal(topSpeedInKilometers, sut.TopSpeedInKilometers);
            Assert.Equal(topSpeedInMiles, sut.TopSpeedInMiles);
            Assert.Equal(zeroToHundreds, sut.ZeroToHundreds);
            Assert.Equal(engineModel, sut.EngineModel);
            Assert.Equal(hasTurbocharger, sut.HasSupercharger);
            Assert.Equal(hasSupercharger, sut.HasSupercharger);        
        }

        [Theory]
        [ProjectNotValidData]
        public void ThrowsExceptionDuringUpdate(string projectName, string category, int horsepower,
            float topSpeedInKilometers, float topSpeedInMiles, float zeroToHundreds,
            string engineModel, bool hasTurbocharger, bool hasSupercharger)
        {
            //Arrange
            var carMock = Mock.Of<Car>(x => x.Id == 1);
            var userMock = Mock.Of<User>(x => x.Id == 1);
            var sut = new Project("projectName", "category", 1, 1.0f, 1.0f, 1.0f,
            "engineModel", false, false, carMock, userMock);

            //Act & Assert
            Assert.Throws<ForbiddenValueException>(() => sut.Update(projectName, category,
            horsepower, topSpeedInKilometers, topSpeedInMiles, zeroToHundreds, engineModel,
            hasTurbocharger, hasSupercharger));
        }

        [Fact]
        public void DeleteItself()
        {
            //Arrange
            var carMock = Mock.Of<Car>(x => x.Id == 1);
            var userMock = Mock.Of<User>(x => x.Id == 1);
            var sut = new Project("projectName", "category", 1, 1.0f, 1.0f, 1.0f,
            "engineModel", false, false, carMock, userMock);

            //Act
            sut.Delete();

            //Assert
            Assert.Equal(true, sut.Deleted);
        }
    }
}