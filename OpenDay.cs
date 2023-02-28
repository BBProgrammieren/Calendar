using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    internal class OpenDay
    {
        User user;
 
        public OpenDay(User strUser)
        {
            user = strUser;
        }
        public void Open(int day, int month, int year)
        {
            Console.Clear();
            //Fehler wieso auch immer
            Console.WriteLine(user + "\n----------------------");
            Console.WriteLine("Day: " + day + " Month:" + month + "Year: " + year);
            Console.WriteLine("Meetings:");
        }
    }
}
