using System.Collections;

namespace Calendar;

internal class ChooseRoleValidation
{
    private ArrayList allUsers = new ArrayList();
    public bool CheckRole(string userInfo, ArrayList allUsers)
    {
        this.allUsers = allUsers;   
        var warningInput = false;

        if (allUsers.Contains(userInfo))
            warningInput = false;
        else
            warningInput = true;
        return warningInput;
    }
}