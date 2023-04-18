namespace Calendar;

internal class KeyActions
{
    private Action<int, int, int> Calendar;
    private int chosenDay;
    private int month;
    private int year;

    public KeyActions(int chosenDay, int month, int year)
    {
        this.chosenDay = chosenDay;
        this.month = month;
        this.year = year;
    }

    public void setCal(Action<int, int, int> Calendar)
    {
        this.Calendar = Calendar;
    }

    public void UpArrow(GetDateInfo dateInfo)
    {
        if (chosenDay == 1)
        {
            chosenDay = dateInfo.GetMonthDays(month, year);
            Console.Clear();
            Calendar(month, year, chosenDay);
        }
        else
        {
            chosenDay--;
            Console.Clear();
            Calendar(month, year, chosenDay);
        }
    }

    public void DownArrow(GetDateInfo dateInfo)
    {
        if (chosenDay < dateInfo.GetMonthDays(month, year))
        {
            chosenDay = chosenDay + 1;
            Console.Clear();
            Calendar(month, year, chosenDay);    
        }
        else
        {
            Console.Clear();
            Calendar(month, year, chosenDay = 1);
        }
    }

    public void LeftArrow()
    {
        if (month == 1)
        {
            chosenDay = 1;
            Console.Clear();
            year = year - 1;
            month = 12;
            Calendar(month, year, chosenDay);
        }
        else
        {
            chosenDay = 1;
            Console.Clear();
            month = month - 1;
            Calendar(month, year, chosenDay);
        }
    }

    public void RightArrow()
    {
        if (month == 12)
        {
            chosenDay = 1;
            Console.Clear();
            year = year + 1;
            month = 1;
            Calendar(month, year, chosenDay);
        }
        else
        {
            chosenDay = 1;
            Console.Clear();
            month = month + 1;
            Calendar(month, year, chosenDay);
        }
    }
}