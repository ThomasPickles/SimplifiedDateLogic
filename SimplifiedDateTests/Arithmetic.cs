using System;
using DateArithmetic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimplifiedDateTests
{
    [TestClass]
    public class Arithmetic
    {
        [TestMethod]
        public void SimplifedDate_AddMonths_ShouldReturnCorrectDate()
        {
            // Arrange
            var date = new SimplifiedDate(2017, 12);
            var anotherDate = new SimplifiedDate(2015, 8);

            // Act
            var date1 = date.AddMonths(1);
            var date2 = date.AddMonths(0);
            var date3 = date.AddMonths(-1);
            var date4 = date.SubtractMonths(1);
            var date5 = date.SubtractMonths(-1);
            var months1 = date.GetDateDifferenceInMonths(anotherDate);
            var months2 = anotherDate.GetDateDifferenceInMonths(date);

            // Assert
            Assert.AreEqual(1, date1.Month);
            Assert.AreEqual(2018, date1.Year);
            Assert.AreEqual(12, date2.Month);
            Assert.AreEqual(2017, date2.Year);
            Assert.AreEqual(11, date3.Month);
            Assert.AreEqual(2017, date3.Year);
            Assert.AreEqual(11, date4.Month);
            Assert.AreEqual(2017, date4.Year);
            Assert.AreEqual(1, date5.Month);
            Assert.AreEqual(2018, date5.Year);
            Assert.AreEqual(28, months1);
            Assert.AreEqual(-28, months2);

        }

    }
}
