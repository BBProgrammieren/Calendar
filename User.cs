using System.Collections;

namespace Calendar;
[Serializable]
internal class User
{
    [NonSerialized] private Appointments appointments;
    [NonSerialized] private string strUser;
    private readonly Hashtable table;
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