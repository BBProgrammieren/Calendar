using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    internal class Times 
    {
        private AppointmentManager appointment;
        private Hashtable table;
        private ArrayList times = new ArrayList();
        private int chosenTime = 0;
        private static int maximumTime = 23;
        private static int minimumTime = 0;
        private int chosenDay;
        private int month;
        private int year;
        private UserManager userManager;

       public Times(int chosenDay, int month, int year, UserManager userManager)
        {
            this.chosenDay = chosenDay;
            this.month = month;
            this.year = year;
            this.userManager = userManager;
            setTimes();
            showTime(chosenTime);
        }
        public void showTime(int chosenTime)
        {
            int i = 0;  
            Console.Clear();
            Console.WriteLine("Day:" + chosenDay);
            Console.WriteLine("Month:" + month);
            Console.WriteLine("Year:" + year);
            Console.WriteLine("Choose your time with arrow up/ down button.");
            Console.WriteLine("");
            Console.WriteLine("----------------------");
            Console.WriteLine("");

            foreach (var t in times)
            {
                if (chosenTime == i)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine(t.ToString() + " o'clock: " + showMeeting(i));
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(t.ToString() + " o'clock: " + showMeeting(i));
                }
                i++;
            }
            Console.WriteLine("");
            Console.WriteLine("----------------------");
            Console.WriteLine("");
            Console.WriteLine("Press Enter: show appointment");
            Console.WriteLine("Press D: Delete all appointments");
            Console.WriteLine("Press A: Show alternative times");
            Console.WriteLine("Press Q: Quit and go back");
            reader();
        }

        public void reader()
        {
           ConsoleKeyInfo cki = Console.ReadKey();
            if( cki.Key == ConsoleKey.DownArrow)
            {
                if(chosenTime < maximumTime)
                {
                    chosenTime++;
                }
                else
                {
                    chosenTime = 0;
                }
                showTime (chosenTime);
            }
            else if ( cki.Key == ConsoleKey.UpArrow)
            {
                if(chosenTime > minimumTime)
                {
                    chosenTime--;
                }
                else
                {
                    chosenTime = 23;
                }
                showTime(chosenTime);
            }
            else if( cki.Key == ConsoleKey.Enter)
            {
                appointment = new AppointmentManager(chosenTime, chosenDay, month, year, userManager);
            }
            else if (cki.Key == ConsoleKey.Q)
            {
                Console.Clear();
                new ShowCalendar(userManager);
            }
            else if (cki.Key == ConsoleKey.D)
            {
                DateTime dateTime = new DateTime(year, month, chosenDay);
                appointment = new AppointmentManager(dateTime, userManager);
                appointment.deleteDayAppointment(year, month, chosenDay);
            }
            else
            {
                reader();
            }
        }
        
        public void setTimes()
        {
            for (int i = 0; i <= maximumTime; i++)
            {
                this.times.Add(i);
            }                
        }

        public string showMeeting(int hour)
        {
            var dateTime = new DateTime(year, month, chosenDay, hour, 0, 0);
            appointment = new AppointmentManager(dateTime, userManager);
            if (appointment.existAppointment() == false)
            {
                return null;
            }
            else
            {
                return appointment.getAppopintmentString(dateTime);
            }           
        }
    }
}
