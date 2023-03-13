using System.Collections;

namespace Calendar;

[Serializable]
internal class Appointments
{
    private Hashtable appointments;

    public Appointments()
    {
        appointments = new Hashtable();
    }

    public void addAppointment(DateTime dateTime, string str)
    {
        appointments.Add(dateTime, str);
    }

    public void deleteAppointment(DateTime dateTime)
    {
        appointments.Remove(dateTime);
    }

    public bool checkNull(DateTime dateTime)
    {
        if (appointments[dateTime] == null)
            return true;
        return false;
    }

    public string getString(DateTime dateTime)
    {
        return appointments[dateTime].ToString();
    }
}