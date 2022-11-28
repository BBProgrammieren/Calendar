using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    internal class ShowCalendar
    {
        private string userInfo;
        public ShowCalendar(string user)
        {
            userInfo = user;
            ShowCurrentUser();
        }

        public void ShowCurrentUser()
        {
            Console.WriteLine(userInfo);    
        }

        public void Calendar()
        {
            Console.WriteLine();
        }
    }
}
