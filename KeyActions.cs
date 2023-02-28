using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    internal class KeyActions
    {
        private int month;
        private int year;
        private int chosenDay;
        private Action <int, int, int> Calendar;

        public KeyActions(int chosenDay, int month, int year)
        {
            this.chosenDay = chosenDay; 
            this.month = month;
            this.year = year;
        }

        public void setCal(Action <int, int, int> Calendar)
        {
            this.Calendar = Calendar;
        }

        public void UpArrow()
        {
            if (chosenDay == 0 || chosenDay == 1)
            {
                chosenDay = 1;
                Console.Clear();
                Calendar(month, year, chosenDay);
            }
            else
            {
                chosenDay = chosenDay - 1;
                Console.Clear();
                Calendar(month, year, chosenDay);
            }
        }
        public void DownArrow(GetDateInfo dateInfo)
        {
            if (chosenDay == dateInfo.GetMonthDays(month, year))
            {
                Console.Clear();
                Calendar(month, year, dateInfo.GetMonthDays(month, year));
            }
            else
            {
                chosenDay = chosenDay + 1;
                Console.Clear();
                Calendar(month, year, chosenDay);
            }
        }
        public void LeftArrow()
        {
            if (month == 1)
            {
                chosenDay = 0;
                Console.Clear();
                year = year - 1;
                month = 12;
                Calendar(month, year, 0);
            }
            else
            {
                chosenDay = 0;
                Console.Clear();
                month = month - 1;
                Calendar(month, year, 0);
            }
        }

        public void RightArrow()
        {
            if (month == 12)
            {
                chosenDay = 0;
                Console.Clear();
                year = year + 1;
                month = 1;
                Calendar(month, year, 0);
            }
            else
            {
                chosenDay = 0;
                Console.Clear();
                month = month + 1;
                Calendar(month, year, 0);
            }
        }
    }
}

