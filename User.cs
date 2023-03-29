using System.Collections;

namespace Calendar;
[Serializable]
internal class User
{
    [NonSerialized] private Appointments appointments;
    [NonSerialized] private string strUser;
    private Hashtable table;
    private Serializer serializer;

    public User()
    {
        table = new Hashtable();
        serializer = new Serializer();
    }
    public Hashtable getHashtable()
    {
        return table;
    }

    public Appointments getAppointment(string strUser)
    {
        this.strUser = strUser; 
        appointments = (Appointments)table[strUser];
        if (appointments == null)
        {
            return appointments = new Appointments();
        }           
        else
        {
            return appointments;
        }      
    }

    public void setAppointment(Appointments ap)
    {
        this.appointments = ap;
        table[strUser] = appointments;
    }

    public void addUser(string strUser, Appointments appointments)
    {
        this.strUser = strUser;
        this.appointments = appointments;
        table.Add(strUser, appointments);
    }


    public void deleteUser(string strUser)
    {
        table.Remove(strUser);
    }

    public bool getBool()
    {
        if (table.ContainsKey(strUser))
            return true;
        return false;
    }
}