using Microsoft.VisualStudio.TestTools.UnitTesting;
using DateArithmetic;

namespace SimplifiedDateTests
{

    [TestClass]
    public class LeapYears
    {
    
        [TestMethod]
        public void SimplifiedDate_UsingMidFebruary_ShouldRoundCorrectlyForLeapYears()
        {
            // Arrange + Act
            var leapYearDate = new SimplifiedDate(new System.DateTime(2016, 2, 15), MonthRounding.MonthNearest);
            var nonLeapYearDate = new SimplifiedDate(new System.DateTime(2017, 2, 15), MonthRounding.MonthNearest);
            
            // Assert
            Assert.AreEqual(2, leapYearDate.Month); // 29 days, so the 15th rounds down
            Assert.AreEqual(3, nonLeapYearDate.Month); // 28 days, so 15th rounds up
        }
    }
}
