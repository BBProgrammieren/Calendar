using System.Collections;

namespace Calendar;

internal class User

{
    private Appointments appointments;
    private string strUser;
    private readonly Hashtable user = new();

    public User()
    {

    }
    public Hashtable getHashtable()
    {
        return user;
    }

    public void addUser(string strUser, Appointments appointments)
    {
        this.strUser = strUser;
        this.appointments = appointments;
        user.Add(strUser, appointments);
    }


    public void deleteUser()
    {
        user.Remove(strUser);
    }

    public bool getBool()
    {
        if (user.ContainsKey(strUser))
            return true;
        return false;
    }
}