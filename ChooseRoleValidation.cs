namespace Calendar;

internal class ChooseRoleValidation
{
    public bool CheckRole(string userInfo)
    {
        var warningInput = false;

        if (userInfo == "1" || userInfo == "2" || userInfo == "3")
            warningInput = false;
        else
            warningInput = true;
        return warningInput;
    }
}