using System.Collections;

namespace Calendar;

internal class UserManager
{
    private Appointments appointments;
    private string strUser; 
    private User user;
    private Serializer serializer;

    public UserManager()
    {
        this.appointments = new Appointments();
        this.serializer = new Serializer();
        this.user = serializer.userDeSerializeNow();       
    }

    public UserManager(string strUser)
    {
        this.serializer = new Serializer();
        this.user = serializer.userDeSerializeNow();
        this.strUser = strUser; 
        this.appointments = user.getAppointment(strUser);        
    }

    public string Name()
    {
        return strUser;
    }

    public void updateAppointment(Appointments ap)
    {
        user.setAppointment(ap);
        serializer.userSerializeNow(user);
    }

    public void addNewUser(string name)
    {
        user.addUser(name, appointments);
        serializer.userSerializeNow(user);
    }

    public void deleteUser(string strUser) 
    {
        user.deleteUser(strUser);
        serializer.SerializeNow(user, appointments);
    }

    public bool getUserInfo()
    {
        if (user.getHashtable().ContainsKey(strUser))
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
            list.Add(key);
        }
        return list;
    }
}