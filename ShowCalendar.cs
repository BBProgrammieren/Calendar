using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    internal class ShowCalendar
    {
        GetDateInfo di = new GetDateInfo();
        private string userInfo;
        public ShowCalendar(string user)
        {
            userInfo = user;
            ShowCurrentUser();
            Calendar();
        }

        public void ShowCurrentUser()
        {
            Console.WriteLine(userInfo);   
            Console.WriteLine("----------------------");
        }

        public void Calendar()
        {
            Console.WriteLine("Month:" + di.CurrentMonthNumber());
            Console.WriteLine("----------------------");
            for(int i = 1; i <= di.CurrentDaysNumber(); i++)
            {
                Console.WriteLine(i);
            }
            
        }
    }
}
