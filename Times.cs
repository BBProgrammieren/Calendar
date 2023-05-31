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
            else if (cki.Key == ConsoleKey.W)
            {
                Console.Clear();
                Console.WriteLine("The key 'W' have no function!");
                Console.WriteLine("Please read the info!");
                Console.WriteLine("Press enter to continue!");
                Console.ReadKey();
                Console.Clear();
                new ShowCalendar(userManager);
            }
            else if (cki.Key == ConsoleKey.E)
            {
                Console.Clear();
                Console.WriteLine("The key 'E' have no function!");
                Console.WriteLine("Please read the info!");
                Console.WriteLine("Press enter to continue!");
                Console.ReadKey();
                Console.Clear();
                new ShowCalendar(userManager);
            }
            else if (cki.Key == ConsoleKey.R)
            {
                Console.Clear();
                Console.WriteLine("The key 'R' have no function!");
                Console.WriteLine("Please read the info!");
                Console.WriteLine("Press enter to continue!");
                Console.ReadKey();
                Console.Clear();
                new ShowCalendar(userManager);
            }
            else if (cki.Key == ConsoleKey.T)
            {
                Console.Clear();
                Console.WriteLine("This key have no function!");
                Console.WriteLine("Please read the info!");
                Console.WriteLine("Press enter to continue!");
                Console.ReadKey();
                Console.Clear();
                new ShowCalendar(userManager);
            }
            else if (cki.Key == ConsoleKey.Z)
            {
                Console.Clear();
                Console.WriteLine("This key have no function!");
                Console.WriteLine("Please read the info!");
                Console.WriteLine("Press enter to continue!");
                Console.ReadKey();
                Console.Clear();
                new ShowCalendar(userManager);
            }
            else if (cki.Key == ConsoleKey.U)
            {
                Console.Clear();
                Console.WriteLine("This key have no function!");
                Console.WriteLine("Please read the info!");
                Console.WriteLine("Press enter to continue!");
                Console.ReadKey();
                Console.Clear();
                new ShowCalendar(userManager);
            }
            else if (cki.Key == ConsoleKey.I)
            {
                Console.Clear();
                Console.WriteLine("This key have no function!");
                Console.WriteLine("Please read the info!");
                Console.WriteLine("Press enter to continue!");
                Console.ReadKey();
                Console.Clear();
                new ShowCalendar(userManager);
            }
            else if (cki.Key == ConsoleKey.O)
            {
                Console.Clear();
                Console.WriteLine("This key have no function!");
                Console.WriteLine("Please read the info!");
                Console.WriteLine("Press enter to continue!");
                Console.ReadKey();
                Console.Clear();
                new ShowCalendar(userManager);
            }
            else if (cki.Key == ConsoleKey.P)
            {
                Console.Clear();
                Console.WriteLine("This key have no function!");
                Console.WriteLine("Please read the info!");
                Console.WriteLine("Press enter to continue!");
                Console.ReadKey();
                Console.Clear();
                new ShowCalendar(userManager);
            }
            else if (cki.Key == ConsoleKey.A)
            {
                Console.Clear();
                Console.WriteLine("This key have no function!");
                Console.WriteLine("Please read the info!");
                Console.WriteLine("Press enter to continue!");
                Console.ReadKey();
                Console.Clear();
                new ShowCalendar(userManager);
            }
            else if (cki.Key == ConsoleKey.S)
            {
                Console.Clear();
                Console.WriteLine("This key have no function!");
                Console.WriteLine("Please read the info!");
                Console.WriteLine("Press enter to continue!");
                Console.ReadKey();
                Console.Clear();
                new ShowCalendar(userManager);
            }
            else if (cki.Key == ConsoleKey.F)
            {
                Console.Clear();
                Console.WriteLine("This key have no function!");
                Console.WriteLine("Please read the info!");
                Console.WriteLine("Press enter to continue!");
                Console.ReadKey();
                Console.Clear();
                new ShowCalendar(userManager);
            }
            else if (cki.Key == ConsoleKey.G)
            {
                Console.Clear();
                Console.WriteLine("The key 'G' have no function!");
                Console.WriteLine("Please read the info!");
                Console.WriteLine("Press enter to continue!");
                Console.ReadKey();
                Console.Clear();
                new ShowCalendar(userManager);
            }
            else if (cki.Key == ConsoleKey.H)
            {
                Console.Clear();
                Console.WriteLine("The key 'H' have no function!");
                Console.WriteLine("Please read the info!");
                Console.WriteLine("Press enter to continue!");
                Console.ReadKey();
                Console.Clear();
                new ShowCalendar(userManager);
            }
            else if (cki.Key == ConsoleKey.J)
            {
                Console.Clear();
                Console.WriteLine("The key 'J' have no function!");
                Console.WriteLine("Please read the info!");
                Console.WriteLine("Press enter to continue!");
                Console.ReadKey();
                Console.Clear();
                new ShowCalendar(userManager);
            }
            else if (cki.Key == ConsoleKey.K)
            {
                Console.Clear();
                Console.WriteLine("The key 'K' have no function!");
                Console.WriteLine("Please read the info!");
                Console.WriteLine("Press enter to continue!");
                Console.ReadKey();
                Console.Clear();
                new ShowCalendar(userManager);
            }
            else if (cki.Key == ConsoleKey.L)
            {
                Console.Clear();
                Console.WriteLine("The key 'L' have no function!");
                Console.WriteLine("Please read the info!");
                Console.WriteLine("Press enter to continue!");
                Console.ReadKey();
                Console.Clear();
                new ShowCalendar(userManager);
            }
            else if (cki.Key == ConsoleKey.Y)
            {
                Console.Clear();
                Console.WriteLine("The key 'Y' have no function!");
                Console.WriteLine("Please read the info!");
                Console.WriteLine("Press enter to continue!");
                Console.ReadKey();
                Console.Clear();
                new ShowCalendar(userManager);
            }
            else if (cki.Key == ConsoleKey.X)
            {
                Console.Clear();
                Console.WriteLine("The key 'X' have no function!");
                Console.WriteLine("Please read the info!");
                Console.WriteLine("Press enter to continue!");
                Console.ReadKey();
                Console.Clear();
                new ShowCalendar(userManager);
            }
            else if (cki.Key == ConsoleKey.C)
            {
                Console.Clear();
                Console.WriteLine("The key 'C' have no function!");
                Console.WriteLine("Please read the info!");
                Console.WriteLine("Press enter to continue!");
                Console.ReadKey();
                Console.Clear();
                new ShowCalendar(userManager);
            }
            else if (cki.Key == ConsoleKey.V)
            {
                Console.Clear();
                Console.WriteLine("The key 'V' have no function!");
                Console.WriteLine("Please read the info!");
                Console.WriteLine("Press enter to continue!");
                Console.ReadKey();
                Console.Clear();
                new ShowCalendar(userManager);
            }
            else if (cki.Key == ConsoleKey.B)
            {
                Console.Clear();
                Console.WriteLine("The key 'B' have no function!");
                Console.WriteLine("Please read the info!");
                Console.WriteLine("Press enter to continue!");
                Console.ReadKey();
                Console.Clear();
                new ShowCalendar(userManager);
            }
            else if (cki.Key == ConsoleKey.N)
            {
                Console.Clear();
                Console.WriteLine("The key 'N' have no function!");
                Console.WriteLine("Please read the info!");
                Console.WriteLine("Press enter to continue!");
                Console.ReadKey();
                Console.Clear();
                new ShowCalendar(userManager);
            }
            else if (cki.Key == ConsoleKey.M)
            {
                Console.Clear();
                Console.WriteLine("The key 'M' have no function!");
                Console.WriteLine("Please read the info!");
                Console.WriteLine("Press enter to continue!");
                Console.ReadKey();
                Console.Clear();
                new ShowCalendar(userManager);
            }
            else if (cki.Key == ConsoleKey.Spacebar)
            {
                Console.Clear();
                Console.WriteLine("The spacebar have no function!");
                Console.WriteLine("Please read the info!");
                Console.WriteLine("Press enter to continue!");
                Console.ReadKey();
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
