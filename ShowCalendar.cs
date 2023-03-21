namespace Calendar;

internal class ShowCalendar
{
    private AppointmentManager appointment;
    private int chosenDay;

    private readonly GetDateInfo dateInfo = new();
    private readonly KeyActions key;
    private int month;
    private readonly UserManager userInfo;
    private int year;

    public ShowCalendar(UserManager user)
    {
        chosenDay = 1;
        month = dateInfo.CurrentMonthNumber();
        year = dateInfo.CurrentYearNumber();
        userInfo = user;
        key = new KeyActions(chosenDay, month, year);
        key.setCal(Calendar);
        Calendar(dateInfo.CurrentMonthNumber(), dateInfo.CurrentYearNumber(), chosenDay);
    }

    public void ShowCurrentUser()
    {
        Console.WriteLine(userInfo.Name() + "\n----------------------");
        //Console.WriteLine("----------------------");
    }

    private void Calendar(int month, int year, int chosenDay)
    {
        this.month = month;
        this.year = year;
        this.chosenDay = chosenDay;
        ShowCurrentUser();
        Console.WriteLine("Month:" + month);
        Console.WriteLine("Year:" + year);
        Console.WriteLine("----------------------");

        for (var i = 1; i <= dateInfo.GetMonthDays(month, year); i++)
            if (i == DateTime.Now.Day && DateTime.Now.Month == month && DateTime.Now.Year == year)
            {
                if (chosenDay == i) Console.BackgroundColor = ConsoleColor.Red;
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

        Console.WriteLine("");
        Console.WriteLine("----------------------");
        Console.WriteLine("");
        Console.WriteLine("Infos:");
        Console.WriteLine("Arrow left: previous month | Arrow right: next month");
        Console.WriteLine("Press A: Show all meetings");
        Console.WriteLine("Press Q: Quit and go Start");

        Reader();
    }

    public void Reader()
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
            appointment = new AppointmentManager(chosenDay, month, year, userInfo);
        }
        else if (cki.Key == ConsoleKey.Q)
        {
            role.StartCalendar();
        }
    }
}