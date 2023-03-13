namespace Calendar;

internal class GetDateInfo
{
    private readonly DateTime timeInfo = DateTime.Now;

    public int CurrentYearNumber()
    {
        var year = timeInfo.Year;
        return year;
    }

    public int CurrentMonthNumber()
    {
        var month = timeInfo.Month;
        return month;
    }

    public int CurrentDaysNumber()
    {
        var days = DateTime.DaysInMonth(timeInfo.Year, timeInfo.Month);
        return days;
    }

    public int GetMonthDays(int month, int year)
    {
        var monthInt = month;
        var yearInt = year;
        var days = DateTime.DaysInMonth(yearInt, monthInt);
        return days;
    }

    public void SetDay()
    {
    }
}