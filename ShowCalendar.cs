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

    //zeigt den aktuellen User an 
    public void ShowCurrentUser()
    {
        Console.WriteLine(userManager.Name() + "\n----------------------");
    }

    // zeigt den aktuellen monat an, wenn ausgewählt wird es in grün angezeigt
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

   // zeigt das aktuelle jahr an, wenn ausgewählt wird es in grün angezeigt
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

    //zeigt kalender an 
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

    //fängt eingaben des Benutzers ab und verarbeitet
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
            key.UpArrow(dateInfo);
        }
        else if (cki.Key == ConsoleKey.DownArrow)
        {
            key.DownArrow(dateInfo);
        }
        else if (cki.Key == ConsoleKey.Enter)
        {
            Times times = new Times(chosenDay, month, year, userManager);
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
        else if (cki.Key == ConsoleKey.W)
        {
            Console.Clear();
            Console.WriteLine("This key have no function!");
            Console.WriteLine("Please read the info!");
            Console.WriteLine("Press enter to continue!");
            Console.ReadKey();
            Calendar(this.month, this.year, this.chosenDay);
        }
        else if (cki.Key == ConsoleKey.E)
        {
            Console.Clear();
            Console.WriteLine("This key have no function!");
            Console.WriteLine("Please read the info!");
            Console.WriteLine("Press enter to continue!");
            Console.ReadKey();
            Calendar(this.month, this.year, this.chosenDay);
        }
        else if (cki.Key == ConsoleKey.R)
        {
            Console.Clear();
            Console.WriteLine("This key have no function!");
            Console.WriteLine("Please read the info!");
            Console.WriteLine("Press enter to continue!");
            Console.ReadKey();
            Calendar(this.month, this.year, this.chosenDay);
        }
        else if (cki.Key == ConsoleKey.T)
        {
            Console.Clear();
            Console.WriteLine("This key have no function!");
            Console.WriteLine("Please read the info!");
            Console.WriteLine("Press enter to continue!");
            Console.ReadKey();
            Calendar(this.month, this.year, this.chosenDay);
        }
        else if (cki.Key == ConsoleKey.Z)
        {
            Console.Clear();
            Console.WriteLine("This key have no function!");
            Console.WriteLine("Please read the info!");
            Console.WriteLine("Press enter to continue!");
            Console.ReadKey();
            Calendar(this.month, this.year, this.chosenDay);
        }
        else if (cki.Key == ConsoleKey.U)
        {
            Console.Clear();
            Console.WriteLine("This key have no function!");
            Console.WriteLine("Please read the info!");
            Console.WriteLine("Press enter to continue!");
            Console.ReadKey();
            Calendar(this.month, this.year, this.chosenDay);
        }
        else if (cki.Key == ConsoleKey.I)
        {
            Console.Clear();
            Console.WriteLine("This key have no function!");
            Console.WriteLine("Please read the info!");
            Console.WriteLine("Press enter to continue!");
            Console.ReadKey();
            Calendar(this.month, this.year, this.chosenDay);
        }
        else if (cki.Key == ConsoleKey.O)
        {
            Console.Clear();
            Console.WriteLine("This key have no function!");
            Console.WriteLine("Please read the info!");
            Console.WriteLine("Press enter to continue!");
            Console.ReadKey();
            Calendar(this.month, this.year, this.chosenDay);
        }
        else if (cki.Key == ConsoleKey.P)
        {
            Console.Clear();
            Console.WriteLine("This key have no function!");
            Console.WriteLine("Please read the info!");
            Console.WriteLine("Press enter to continue!");
            Console.ReadKey();
            Calendar(this.month, this.year, this.chosenDay);
        }
        else if (cki.Key == ConsoleKey.A)
        {
            Console.Clear();
            Console.WriteLine("This key have no function!");
            Console.WriteLine("Please read the info!");
            Console.WriteLine("Press enter to continue!");
            Console.ReadKey();
            Calendar(this.month, this.year, this.chosenDay);
        }
        else if (cki.Key == ConsoleKey.S)
        {
            Console.Clear();
            Console.WriteLine("This key have no function!");
            Console.WriteLine("Please read the info!");
            Console.WriteLine("Press enter to continue!");
            Console.ReadKey();
            Calendar(this.month, this.year, this.chosenDay);
        }
        else if (cki.Key == ConsoleKey.F)
        {
            Console.Clear();
            Console.WriteLine("This key have no function!");
            Console.WriteLine("Please read the info!");
            Console.WriteLine("Press enter to continue!");
            Console.ReadKey();
            Calendar(this.month, this.year, this.chosenDay);
        }
        else if (cki.Key == ConsoleKey.G)
        {
            Console.Clear();
            Console.WriteLine("This key have no function!");
            Console.WriteLine("Please read the info!");
            Console.WriteLine("Press enter to continue!");
            Console.ReadKey();
            Calendar(this.month, this.year, this.chosenDay);
        }
        else if (cki.Key == ConsoleKey.H)
        {
            Console.Clear();
            Console.WriteLine("This key have no function!");
            Console.WriteLine("Please read the info!");
            Console.WriteLine("Press enter to continue!");
            Console.ReadKey();
            Calendar(this.month, this.year, this.chosenDay);
        }
        else if (cki.Key == ConsoleKey.J)
        {
            Console.Clear();
            Console.WriteLine("This key have no function!");
            Console.WriteLine("Please read the info!");
            Console.WriteLine("Press enter to continue!");
            Console.ReadKey();
            Calendar(this.month, this.year, this.chosenDay);
        }
        else if (cki.Key == ConsoleKey.K)
        {
            Console.Clear();
            Console.WriteLine("This key have no function!");
            Console.WriteLine("Please read the info!");
            Console.WriteLine("Press enter to continue!");
            Console.ReadKey();
            Calendar(this.month, this.year, this.chosenDay);
        }
        else if (cki.Key == ConsoleKey.L)
        {
            Console.Clear();
            Console.WriteLine("This key have no function!");
            Console.WriteLine("Please read the info!");
            Console.WriteLine("Press enter to continue!");
            Console.ReadKey();
            Calendar(this.month, this.year, this.chosenDay);
        }
        else if (cki.Key == ConsoleKey.Y)
        {
            Console.Clear();
            Console.WriteLine("This key have no function!");
            Console.WriteLine("Please read the info!");
            Console.WriteLine("Press enter to continue!");
            Console.ReadKey();
            Calendar(this.month, this.year, this.chosenDay);
        }
        else
        {
            reader();
        }
    }

//schaut ob die Taste A gedrückt wurde
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

    //für den jeweiligen Tag werden alle Stunden angeschaut, ob diese meetings enthalten
    public string showMeeting(int i, int month, int year)
    {
        bool existing = false;
        for(int j = 0; j < 24; j++)
        {
            var date = new DateTime(year, month, i, j, 0, 0);
            AppointmentManager manager = new AppointmentManager(date, this.userManager);
            if (active && manager.existAppointment())
            { 
                existing = true;
            }
        }
              
        if (active && existing)
        {
            string str = "  ---  Appointment existing!";
            return str;
        }
        else
        {
            return "";
        }
    }

    //abfrage, ob user gelöscht werden soll
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