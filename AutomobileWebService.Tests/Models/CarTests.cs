using AutomobileWebService.Business_Logic.Extras.Custom_Exceptions;
using AutomobileWebService.Business_Logic.Models;
using NUnit.Framework;
using System;

namespace AutomobileWebService.Tests.Models
{
    [TestFixture]
    public class CarTests
    {
        #region ValidationObjects

        static string[] validNames = { "Fiesta", "mondeo", "MUSTANG" };
        static string[] notValidNames = { null, "", " ", "  " };
        static int[] validNumbers = { 1, 99999 };
        static int[] notValidNumbers = { 0, -100 };
        static DateTime[] validDates =
        {
            new DateTime(1996, 10, 12),
            new DateTime(1587,12,1)
        };

        static DateTime[] notValidDates =
        {
            new DateTime()
        };

        #endregion

        [Test]
        [TestCaseSource("validNames")]
        public void UpdateModelName_ShouldPass(string value)
        {
            Car testCar = new Car(Guid.NewGuid(), "Model1", 200, 2, new DateTime(2000, 8, 10), new Brand(Guid.NewGuid(), "Brand1", new DateTime(2000, 1, 1), new DateTime(2003, 1, 1)));

            testCar.Update(value, testCar.Horsepower, testCar.Generation, testCar.ProdutionDate);

            Assert.AreEqual(value, testCar.Model);
        }

        [Test]
        [TestCaseSource("notValidNames")]
        public void UpdateModelName_ThrowException(string value)
        {
            Car testCar = new Car(Guid.NewGuid(), "Model1", 200, 2, new DateTime(2000, 8, 10), new Brand(Guid.NewGuid(), "Brand1", new DateTime(2000, 1, 1), new DateTime(2003, 1, 1)));

            TestDelegate action = () => testCar.Update(value, testCar.Horsepower, testCar.Generation, testCar.ProdutionDate);

            Assert.Throws<ForbiddenValueException>(action);
        }

        [Test]
        [TestCaseSource("validNumbers")]
        public void UpdateHorsepower_ShouldPass(int value)
        {
            Car testCar = new Car(Guid.NewGuid(), "Model1", 200, 2, new DateTime(2000, 8, 10), new Brand(Guid.NewGuid(), "Brand1", new DateTime(2000, 1, 1), new DateTime(2003, 1, 1)));

            testCar.Update(testCar.Model, value, testCar.Generation, testCar.ProdutionDate);

            Assert.AreEqual(value, testCar.Horsepower);
        }

        [Test]
        [TestCaseSource("notValidNumbers")]
        public void UpdateHorsepower_ThrowException(int value)
        {
            Car testCar = new Car(Guid.NewGuid(), "Model1", 200, 2, new DateTime(2000, 8, 10), new Brand(Guid.NewGuid(), "Brand1", new DateTime(2000, 1, 1), new DateTime(2003, 1, 1)));

            TestDelegate action = () => testCar.Update(testCar.Model, value, testCar.Generation, testCar.ProdutionDate);

            Assert.Throws<ForbiddenValueException>(action);
        }

        [Test]
        [TestCaseSource("validNumbers")]
        public void UpdateGeneration_ShouldPass(int value)
        {
            Car testCar = new Car(Guid.NewGuid(), "Model1", 200, 2, new DateTime(2000, 8, 10), new Brand(Guid.NewGuid(), "Brand1", new DateTime(2000, 1, 1), new DateTime(2003, 1, 1)));

            testCar.Update(testCar.Model, testCar.Horsepower, value, testCar.ProdutionDate);

            Assert.AreEqual(value, testCar.Generation);
        }

        [Test]
        [TestCaseSource("notValidNumbers")]
        public void UpdateGeneration_ThrowException(int value)
        {
            Car testCar = new Car(Guid.NewGuid(), "Model1", 200, 2, new DateTime(2000, 8, 10), new Brand(Guid.NewGuid(), "Brand1", new DateTime(2000, 1, 1), new DateTime(2003, 1, 1)));

            TestDelegate action = () => testCar.Update(testCar.Model, testCar.Horsepower, value, testCar.ProdutionDate);

            Assert.Throws<ForbiddenValueException>(action);
        }

        [Test]
        [TestCaseSource("validDates")]
        public void UpdateProductionDate_ShouldPass(DateTime value)
        {
            Car testCar = new Car(Guid.NewGuid(), "Model1", 200, 2, new DateTime(2000, 8, 10), new Brand(Guid.NewGuid(), "Brand1", new DateTime(2000, 1, 1), new DateTime(2003, 1, 1)));

            testCar.Update(testCar.Model, testCar.Horsepower, testCar.Generation, value);

            Assert.AreEqual(value, testCar.ProdutionDate);
        }

        [Test]
        [TestCaseSource("notValidDates")]
        public void UpdateProductionDate_ThrowException(DateTime value)
        {
            Car testCar = new Car(Guid.NewGuid(), "Model1", 200, 2, new DateTime(2000, 8, 10), new Brand(Guid.NewGuid(), "Brand1", new DateTime(2000, 1, 1), new DateTime(2003, 1, 1)));

            TestDelegate action = () => testCar.Update(testCar.Model, testCar.Horsepower, testCar.Generation, value);

            Assert.Throws<ForbiddenValueException>(action);
        }
    }
}
