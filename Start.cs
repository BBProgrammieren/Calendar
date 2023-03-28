using System.Runtime.InteropServices;

namespace Calendar;

internal class Start
{
    public static void Main()
    {
        UserManager userManager = new UserManager();
        Role role = new Role(userManager);
    }
}