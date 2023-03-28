using System.Collections;

namespace Calendar;

internal class UserManager
{
    private Appointments appointments;
    private string name;
    private User user;
    private Serializer serializer;

    public UserManager()
    {
        this.appointments = new Appointments();
        this.user = new User();
        this.serializer = new Serializer();
        this.user = serializer.userDeSerializeNow();
        this.appointments = serializer.appointmentDeSerializeNow();
    }

    public string Name()
    {
        return name;
    }

    public void addNewUser(string name)
    {
        user.addUser(name, appointments);
        serializer.SerializeNow(user, appointments);
    }

    public void deleteUser(string name) 
    {
        user.deleteUser(name);
        serializer.SerializeNow(user, appointments);
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