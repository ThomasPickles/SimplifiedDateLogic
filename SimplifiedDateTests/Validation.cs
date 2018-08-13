using System;
using DateArithmetic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimplifiedDateTests
{
    [TestClass]
    public class Validation
    {
        [TestMethod]
        public void SimplifiedDate_InitialisedWithOutOfRangeValues_ShouldThrowException()
        {
            // Arrange
            Action createInvalidDate = () => new SimplifiedDate(2018, 13); // There's no 13th month!
            
            // Act / Assert            
            Assert.ThrowsException<ArgumentOutOfRangeException>(createInvalidDate);

        }
    }
}
