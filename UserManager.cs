using System.Collections;

namespace Calendar;

internal class UserManager
{
    private readonly Appointments appointments;
    private readonly string name;
    private readonly User user = new User();

    public UserManager(string name)
    {
        this.name = name;
        appointments = new Appointments();
    }

    public UserManager()
    {

    }

    public string Name()
    {
        return name;
    }

    public void addNewUser()
    {
        user.addUser(name, appointments);
    }

    public bool getUserInfo()
    {
        if (user.getHashtable().ContainsKey(name))
        {
            return true;
        }
            else
        {
            return false;
        }    
    }

    public Appointments getUserAppointment()
    {
        return appointments;
    }

    public ArrayList getListUser()
    {
        ArrayList list = new ArrayList(); 
        foreach (object key in user.getHashtable().Keys)
        {
            list.Add(String.Format("{0}: {1}", key, user.getHashtable()[key]));
        }
        return list;
    }
}