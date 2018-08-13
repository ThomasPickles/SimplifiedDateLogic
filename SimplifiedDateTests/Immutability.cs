using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DateArithmetic;

namespace SimplifiedDateTests
{
    /// <summary>
    /// Test that the object isn't changed as a side effect
    /// of the arithmetic operations
    /// </summary>
    [TestClass]
    public class Immutability
    {       

        [TestMethod]
        public void SimplifiedDate_AddMonths_ShouldNotChangeObject()
        {
            // Arrange
            var date = new SimplifiedDate(new System.DateTime(2017, 12, 31), MonthRounding.MonthLast);
            var expectedDate = new SimplifiedDate(new System.DateTime(2017, 12, 31), MonthRounding.MonthLast);

            // Act
            date.AddMonths(1);
                        
            // Assert - enumerate the public properties 
            Assert.AreEqual(expectedDate.Year, date.Year);
            Assert.AreEqual(expectedDate.Month, date.Month);

        }

        [TestMethod]
        public void SimplifiedDate_AddMonths_ShouldReturnCorrectNewObject()
        {
            // Arrange
            var date = new SimplifiedDate(new System.DateTime(2017, 12, 31), MonthRounding.MonthLast);
            var expectedDate = new SimplifiedDate(new System.DateTime(2018, 1, 31), MonthRounding.MonthLast);

            // Act 
            var newDate = date.AddMonths(1);
            
            // Assert
            Assert.AreEqual(expectedDate.Month, newDate.Month);
            Assert.AreEqual(expectedDate.Year, newDate.Year);
        }

    }
}
