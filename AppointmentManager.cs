﻿namespace Calendar;

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

    private void checkDateAppointment()
    {
        if (ap.checkNull(dateTime))
            setDialog();
        else
            getDialog();
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
        Console.Clear();
        Console.WriteLine(user.Name() + "\n----------------------");
        Console.WriteLine("Day:" + chosenDay);
        Console.WriteLine("Month:" + month);
        Console.WriteLine("Year:" + year);
        Console.WriteLine("----------------------");
        Console.WriteLine("Set Appointment:");
        readEntry();
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
        Console.WriteLine("----------------------");
        Console.WriteLine("Your Appointment:");
        Console.WriteLine(strAppointment);
    }

    public void readEntry()
    {
        ConsoleKeyInfo cki;

        if (strAppointment == null || strAppointment == "")
        {
            strAppointment = Console.ReadLine();
            showSecondDialog(strAppointment);
        }

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
            if (strAppointment == null)
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
    }

    public void deleteAppointment()
    {
        ap.deleteAppointment(dateTime);
        Console.Clear();
        new ShowCalendar(user);
    }

    public void saveAppointment(string str)
    {
        if (ap.checkNull(dateTime))
        {
            ap.addAppointment(dateTime, str);
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
        //int i = int.Parse(year.ToString("0000") + month.ToString("00") + chosenDay.ToString("00"));
        //DateTime dt = DateTime.Parse(i.ToString());
        return date;
    }
}