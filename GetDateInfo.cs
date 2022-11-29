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
        int monthInt;
        int yearInt;

        public GetDateInfo(int monthNumber, int yearNumber)
        {
            monthInt = monthNumber;
            yearInt = yearNumber;   
        }
        public GetDateInfo() { }
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

        public int GetMonthDays()
        {
            var days = DateTime.DaysInMonth(yearInt, monthInt);
            return days;
        }
    }
}
