using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    internal class ChooseRoleValidation
    {
        public Boolean CheckRole(string userInfo)
        {
            var warningInput = false;

            if (userInfo == "1" || userInfo == "2" || userInfo == "3")
            {
                warningInput = false;
            }
            else
            {
                warningInput = true;
            }
            return warningInput;
        }
    }
}
