namespace Calendar;

internal class AppointmentManager
{
    private readonly Appointments ap;
    private readonly int chosenDay;
    private readonly DateTime dateTime;
    private readonly int month;
    private string strAppointment;
    private readonly UserManager user;
    private readonly int year;

    public AppointmentManager(int chosenDay, int month, int year, UserManager user)
    {
        this.chosenDay = chosenDay;
        this.month = month;
        this.year = year;
        this.user = user;
        strAppointment = null;
        dateTime = IntegerToDateTime(this.chosenDay, this.month, this.year);
        ap = user.getUserAppointment();
        checkDateAppointment();
    }

    public AppointmentManager(DateTime dateTime, UserManager user)
    {
        this.chosenDay = chosenDay;
        this.month = month;
        this.year = year;
        this.user = user;
        strAppointment = null;
        this.dateTime = dateTime;
        ap = user.getUserAppointment();
    }

    private void checkDateAppointment()
    {
        if (ap.checkNull(dateTime))
            setDialog();
        else
            getDialog();
    }

    public bool existAppointment()
    {
        if (ap.checkNull(dateTime))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void getDialog()
    {
        if (ap.getString(dateTime) == "" || ap.getString(dateTime) == null)
        {
            setDialog();
            return;
        }

        strAppointment = ap.getString(dateTime);
        showSecondDialog(strAppointment);
        readEntry();
    }

    public void setDialog()
    {
        showDialog();
        readEntry();
    }

    public void showDialog()
    {
        Console.Clear();
        Console.WriteLine(user.Name() + "\n----------------------");
        Console.WriteLine("Day:" + chosenDay);
        Console.WriteLine("Month:" + month);
        Console.WriteLine("Year:" + year);
        Console.WriteLine("----------------------");
        Console.WriteLine("Set Appointment:");
    }

    public void showSecondDialog(string strAppointment)
    {
        Console.Clear();
        Console.WriteLine(user.Name() + "\n----------------------");
        Console.WriteLine("Day:" + chosenDay);
        Console.WriteLine("Month:" + month);
        Console.WriteLine("Year:" + year);
        Console.WriteLine("----------------------");
        Console.WriteLine("Press S: Save and Quit");
        Console.WriteLine("Press E: Edit");
        Console.WriteLine("Press D: Delete and Quit");
        Console.WriteLine("Press Q: Quit");
        Console.WriteLine("----------------------");
        Console.WriteLine("Your Appointment:");
        Console.WriteLine(strAppointment);
    }

    public void readEntry()
    {
        bool entryEmpty = true;
        do {
            if (strAppointment == null || strAppointment == "")
            {               
                Console.Clear();
                showDialog();
                strAppointment = Console.ReadLine();               
            }
            if (strAppointment != "")
            {
                entryEmpty = false;
                showSecondDialog(strAppointment);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("Please enter a valid appointment!");
                Console.WriteLine("Press Enter to continue.");
                Console.ReadLine();
                entryEmpty = true;
            }
        }while (entryEmpty == true);

        ConsoleKeyInfo cki;
        cki = Console.ReadKey();

        if (cki.Key == ConsoleKey.S)
        {
            if (strAppointment == null || strAppointment == "")
            {
                Console.WriteLine("");
                Console.WriteLine("Please enter a valid appointment!");
                Console.ReadLine();
                setDialog();
            }
            else
            {
                saveAppointment(strAppointment);
            }
        }
        else if (cki.Key == ConsoleKey.D)
        {
            if (strAppointment == null || strAppointment == "")
            {
                Console.WriteLine("Nothing to delete here!");
                Console.WriteLine("Press Enter to continue.");
                Console.ReadLine();
                setDialog();
            }
            else
            {
                deleteAppointment();
            }
        }
        else if (cki.Key == ConsoleKey.E)
        {
            if (strAppointment == null)
            {
                Console.WriteLine("Editing not possibe!");
                setDialog();
            }
            else
            {
                deleteAppointment();
                setDialog();
            }
        }
        else if (cki.Key == ConsoleKey.Q)
        {
            Console.Clear();
            new ShowCalendar(user);
        }
    }

    public void deleteAppointment()
    {
        ap.deleteAppointment(dateTime);
        user.updateAppointment(ap);
        Console.Clear();
        new ShowCalendar(user);
    }

    public void saveAppointment(string str)
    {
        if (ap.checkNull(dateTime))
        {
            ap.addAppointment(dateTime, str);
            user.updateAppointment(ap);    //serialisieren
            Console.Clear();
            new ShowCalendar(user);
        }
        else
        {
            Console.Clear();
            new ShowCalendar(user);
        }     
    }

    public DateTime IntegerToDateTime(int chosenDay, int month, int year)
    {
        var date = new DateTime(year, month, chosenDay);
        return date;
    }
}