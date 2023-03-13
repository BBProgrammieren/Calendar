namespace Calendar;

internal class UserManager
{
    private readonly Appointments appointments;
    private readonly string name;
    private readonly User user = new();

    public UserManager(string name)
    {
        this.name = name;
        appointments = new Appointments();
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
            return true;
        return false;
    }

    public Appointments getUserAppointment()
    {
        return appointments;
    }
}