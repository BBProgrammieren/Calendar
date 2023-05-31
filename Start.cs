using System.Runtime.InteropServices;

namespace Calendar;

internal class Start
{
    private Role role;
        public void Main()
    {
       UserManager userManager = new UserManager();
        role = new Role(userManager);
    }
}