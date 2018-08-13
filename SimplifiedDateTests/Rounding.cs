using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DateArithmetic;

namespace SimplifiedDateTests
{
    /// <summary>
    /// Summary description for Rounding
    /// </summary>
    [TestClass]
    public class Rounding
    {

        // (Resolve ambiguity about how to measure month end
        // in the unit tests.  We typically wouldn't want time
        // of day to affect whether we round to start or end
        // of month)


        [TestMethod]
        public void SimplifiedDate_UsingEndOfMonthValues_ShouldReturnCorrectRounding()
        {
            // Arrange
            var lateMonthDate = new System.DateTime(2017, 12, 31);

            // Act
            var dateMonthLast = new SimplifiedDate(lateMonthDate, MonthRounding.MonthLast);
            var dateMonthNearest = new SimplifiedDate(lateMonthDate, MonthRounding.MonthNearest);

            // Assert

            // Take start of month
            Assert.AreEqual(2017, dateMonthLast.Year);
            Assert.AreEqual(12, dateMonthLast.Month);
            // Round up
            Assert.AreEqual(2018, dateMonthNearest.Year);
            Assert.AreEqual(1, dateMonthNearest.Month);
        }
    }
}
