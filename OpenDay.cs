namespace Calendar;

internal class OpenDay
{
    private readonly UserManager user;

    public OpenDay(UserManager strUser)
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