namespace Calendar;

internal class ShowCalendar
{
    private AppointmentManager appointment;
    private int chosenDay;

    private readonly GetDateInfo dateInfo = new();
    private readonly KeyActions key;
    private int month;
    private readonly UserManager userManager;
    private int year;
    private bool saved;
    private bool active = false;

    public ShowCalendar(UserManager userManager)
    {
        this.saved = false;
        chosenDay = 1;
        month = dateInfo.CurrentMonthNumber();
        year = dateInfo.CurrentYearNumber();
        this.userManager = userManager;
        key = new KeyActions(chosenDay, month, year);
        key.setCal(Calendar);
        Calendar(dateInfo.CurrentMonthNumber(), dateInfo.CurrentYearNumber(), chosenDay);
    }

    public void ShowCurrentUser()
    {
        Console.WriteLine(userManager.Name() + "\n----------------------");
    }

    public void showCurrentMonth()
    {
        Console.Write("Month:");
        if (month == DateTime.Now.Month && DateTime.Now.Year == year)
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
       
        Console.Write(month);    
        Console.ResetColor();
    }

    public void showCurrentYear()   
    {
        Console.WriteLine();
        Console.Write("Year:");
        if (DateTime.Now.Year == year)
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }

        Console.Write(year);
        Console.ResetColor();
        Console.WriteLine();
    }

    private void Calendar(int month, int year, int chosenDay)   
    {
        Console.Clear();
        this.month = month;
        this.year = year;
        this.chosenDay = chosenDay;
        ShowCurrentUser();
        showCurrentMonth();
        showCurrentYear();
        Console.WriteLine("----------------------");

        
            if (active)
            {
              for (var i = 1; i <= dateInfo.GetMonthDays(month, year); i++)
                if (i == DateTime.Now.Day && DateTime.Now.Month == month && DateTime.Now.Year == year)
                {
                    if (chosenDay == i)
                        Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(i + showMeeting(i, month, year));
                    Console.ResetColor();
                }
                else if (chosenDay == i)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine(i + showMeeting(i, month, year));
                    Console.ResetColor();
                }

                else
                {
                    Console.WriteLine(i + showMeeting(i, month, year));
                }
            }
            else
            {
                for (var i = 1; i <= dateInfo.GetMonthDays(month, year); i++)
                    if (i == DateTime.Now.Day && DateTime.Now.Month == month && DateTime.Now.Year == year)
                    {
                        if (chosenDay == i)
                            Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(i);
                        Console.ResetColor();
                    }
                    else if (chosenDay == i)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine(i);
                        Console.ResetColor();
                    }

                    else
                    {
                        Console.WriteLine(i);
                    }
            }

        Console.WriteLine("");
        Console.WriteLine("----------------------");
        Console.WriteLine("");
        Console.WriteLine("Infos:");
        Console.WriteLine("Arrow left: previous month | Arrow right: next month");
        Console.WriteLine("Arrow up: previous day | Arrow down: next day");
        if (active)
        {
            Console.WriteLine("Press A: Don't show all meetings");
        }
        else
        {
            Console.WriteLine("Press A: Show all meetings");
        }      
        Console.WriteLine("Press D: Delete user");
        Console.WriteLine("Press Q: Quit and go Start");

        reader();
    }

    public void reader()
    {
        ConsoleKeyInfo cki;
        cki = Console.ReadKey();
        if (cki.Key == ConsoleKey.LeftArrow)
        {
            key.LeftArrow();
        }
        else if (cki.Key == ConsoleKey.RightArrow)
        {
            key.RightArrow();
        }
        else if (cki.Key == ConsoleKey.UpArrow)
        {
            key.UpArrow();
        }
        else if (cki.Key == ConsoleKey.DownArrow)
        {
            key.DownArrow(dateInfo);
        }
        else if (cki.Key == ConsoleKey.Enter)
        {
            appointment = new AppointmentManager(chosenDay, month, year, userManager);
        }
        else if (cki.Key == ConsoleKey.Q)
        {
            Role role = new Role(userManager);
        }
        else if (cki.Key == ConsoleKey.S)
        {
            this.saved = true;
        }
        else if (cki.Key == ConsoleKey.D)
        {
            deletingUser();
        }
        else if (cki.Key == ConsoleKey.A)
        {
            showAllMeetings(active);
        }
        else
        {
            reader();
        }
    }

    public void showAllMeetings(bool active)
    {

        if (active == false)
        {
            this.active = true;
            Calendar(this.month, this.year, this.chosenDay);     
        }
        else
        {
            this.active = false;
            Calendar(this.month, this.year, this.chosenDay);
        }
    }

    public string showMeeting(int i, int month, int year)
    {
        var date = new DateTime(year, month, i);
        AppointmentManager manager = new AppointmentManager(date, this.userManager);
        if (active && manager.existAppointment())
        {
            string str = "  ---  Appointment existing!";
            return str;
        }
        else
        {
            return "";
        }
    }

    public void deletingUser()
    {
        bool delete = false;
        Console.Clear();
        Console.WriteLine("Are you sure to delete '"+ userManager.Name() + "' and all it's appointments?");
        Console.WriteLine("Please enter Y or N.");

        ConsoleKeyInfo cki;
        cki = Console.ReadKey();

        if (cki.Key == ConsoleKey.Y)
        {
            delete = true;
        }
        else if (cki.Key == ConsoleKey.N)
        {
            delete = false;
        }
        else
        {
            delete = false;
        }

        if (delete)
        {
            Console.Clear();
            userManager.deleteUser(userManager.Name());
            Role role = new Role(userManager);
        }
        else
        {
            Calendar(this.month, this.year, this.chosenDay);
        }
    }
}