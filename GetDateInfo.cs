using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    internal class GetDateInfo
    {
        DateTime timeInfo = DateTime.Now;

        public GetDateInfo() { }
        public int CurrentYearNumber()
        {
            var year = timeInfo.Year;
            return year;
        }
        public int CurrentMonthNumber()
        {
            var month = timeInfo.Month;
            return month;
        }

        public int CurrentDaysNumber()
        {
            var days = DateTime.DaysInMonth(timeInfo.Year, timeInfo.Month);
            return days;
        }

        public int GetMonthDays(int month, int year)
        {
            int monthInt = month;
            int yearInt = year; 
            var days = DateTime.DaysInMonth(yearInt, monthInt);
            return days;
        }

        public void SetDay()
        {

        }
    }
}
