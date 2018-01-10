using AutomobileWebService.Business_Logic.Extras.Custom_Exceptions;
using AutomobileWebService.Business_Logic.Models;
using NUnit.Framework;
using System;

namespace AutomobileWebService.Tests.Models
{
    [TestFixture]
    class BrandTests
    {
        #region ValidationObjects

        static string[] validNames = { "Ford", "dodge", "CHEVROLET" };
        static string[] notValidNames = { null, "", " ", "  " };
        static DateTime[] validStartDates =
        {
            new DateTime(1996, 10, 12),
            new DateTime(1587,12,1)
        };

        static DateTime?[] validEndDates =
        {
            null,
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
        public void UpdateBrandName_ShouldPass(string value)
        {
            Brand testBrand = new Brand(Guid.NewGuid(), "Name1", new DateTime(2000, 12, 22), new DateTime(2003, 11, 10));

            testBrand.Update(value, testBrand.StartDate, testBrand.EndDate);

            Assert.AreEqual(value, testBrand.Name);
        }

        [Test]
        [TestCaseSource("notValidNames")]
        public void UpdateBrandName_ThrowException(string value)
        {
            Brand testBrand = new Brand(Guid.NewGuid(), "Name1", new DateTime(2000, 12, 22), new DateTime(2003, 11, 10));

            TestDelegate action = () => testBrand.Update(value, testBrand.StartDate, testBrand.EndDate);

            Assert.Throws<ForbiddenValueException>(action);
        }

        [Test]
        [TestCaseSource("validStartDates")]
        public void UpdateStartDate_ShouldPass(DateTime value)
        {
            Brand testBrand = new Brand(Guid.NewGuid(), "Name1", new DateTime(2000, 12, 22), new DateTime(2003, 11, 10));

            testBrand.Update(testBrand.Name, value, testBrand.EndDate);

            Assert.AreEqual(value, testBrand.StartDate);
        }

        [Test]
        [TestCaseSource("notValidDates")]
        public void UpdateStartDate_ThrowException(DateTime value)
        {
            Brand testBrand = new Brand(Guid.NewGuid(), "Name1", new DateTime(2000, 12, 22), new DateTime(2003, 11, 10));

            TestDelegate action = () => testBrand.Update(testBrand.Name, value, testBrand.EndDate);

            Assert.Throws<ForbiddenValueException>(action);
        }

        [Test]
        [TestCaseSource("validEndDates")]
        public void UpdateEndDate_ShouldPass(DateTime? value)
        {
            Brand testBrand = new Brand(Guid.NewGuid(), "Name1", new DateTime(2000, 12, 22), new DateTime(2003, 11, 10));

            testBrand.Update(testBrand.Name, testBrand.StartDate, value);

            Assert.AreEqual(value, testBrand.EndDate);
        }

        [Test]
        [TestCaseSource("notValidDates")]
        public void UpdateEndDate_ThrowException(DateTime? value)
        {
            Brand testBrand = new Brand(Guid.NewGuid(), "Name1", new DateTime(2000, 12, 22), new DateTime(2003, 11, 10));

            TestDelegate action = () => testBrand.Update(testBrand.Name, testBrand.StartDate, value);

            Assert.Throws<ForbiddenValueException>(action);
        }
    }
}
