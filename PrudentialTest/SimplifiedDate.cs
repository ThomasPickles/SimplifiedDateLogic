using System;

namespace DateArithmetic
{
    /// <summary>  
    /// This class shares similar behaviour to the existing .NET 
    /// DateTime class: it is immutable, and any arithmetical operations
    /// will return a new instance of the class.
    /// Unless passing in exlicit values for month and year, the client is 
    /// required to specifify the underlying rounding mechanism for converting
    /// a .NET DateTime to a simplified date
    /// </summary>  
    public class SimplifiedDate
    {
        /// Read-only properties can only be set in a constructor.
        /// This makes clear the intent of the class and avoids another developer 
        /// mistakenly modifying them in method body if they want to add 
        /// functionality to the class.
        public readonly int Year; 
        public readonly int Month;

        /// Keep the parameterless constructor private as we don't want to allow 
        /// a client to create an object with non-initialised fields
        private SimplifiedDate()
        {
        }        

        public SimplifiedDate(int year, int month)
        {
            if (month < 1 || month > 12)
            {
                throw new ArgumentOutOfRangeException("Month must be between 1 and 12");
            }
            Year = year;
            Month = month;
        }

        public SimplifiedDate(DateTime dateTime, MonthRounding rounding)
        {

            int year = dateTime.Year, month = dateTime.Month;

            // Here we're piggy backing on the .NET DateTime class
            // This takes care of "carrying the one" for the year
            DateTime startOfMonth = new DateTime(year, month, 1);
            DateTime endOfMonth = startOfMonth.AddMonths(1);

            int daysFromEndOfMonth = (endOfMonth - dateTime).Days;
            int daysFromStartOfMonth = (dateTime - startOfMonth).Days;

            // How we break ties is up to us, but if it's mid-month,
            // let's choose to take the end of month
            if (daysFromEndOfMonth <= daysFromStartOfMonth &&
                rounding == MonthRounding.MonthNearest)
            {
                // Closer to end of month                                      
                Year = endOfMonth.Year;
                Month = endOfMonth.Month;
            }
            else
            {
                // In all other cases take start month values
                Year = startOfMonth.Year;
                Month = startOfMonth.Month;
            }
            
        }

        /// <summary>
        ///  Subtract a SimplifiedDates.
        /// </summary>
        /// <param name="date">The date to subtract</param>
        /// <returns>The difference in months</returns>
        public int GetDateDifferenceInMonths(SimplifiedDate date)
        {
            int yearDifference = this.Year - date.Year;
            int monthDifference = this.Month - date.Month; // can be negative

            return yearDifference * 12 + monthDifference;
        }

        /// <summary>
        ///  Add a number of months to a SimplifiedDates.
        /// </summary>
        /// <param name="numberOfMonths">The number of months to add</param>
        /// <returns>A new instance of SimplifiedDate</returns>
        public SimplifiedDate AddMonths(int numberOfMonths)
        {
            // In practice we might piggy back on the arithmetic
            // of the DateTime class unless we wanted to optimise
            // the performace of these classes

            // Months are 1-indexed (1..12, rather than 0..11), so we need 
            // to be careful with our modulo arithmetic
            int startMonth = this.Month - 1;  // convert to zero-indexing

            int totalMonths = startMonth + numberOfMonths;

            int newYear = this.Year + totalMonths / 12; // integer division returns the floor
            int newMonth = totalMonths % 12;            // and the remainder is the month (zero-indexed)
            
            return new SimplifiedDate(newYear, newMonth + 1); // convert month back to 1-index
        }

        /// <summary>
        ///  Subtract a number of months to a SimplifiedDates.
        /// </summary>
        /// <param name="numberOfMonths">The number of months to subtract</param>
        /// <returns>A new instance of SimplifiedDate</returns>
        public SimplifiedDate SubtractMonths(int numberOfMonths)
        {
            return AddMonths(-numberOfMonths);
        }

    }
}
