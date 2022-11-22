using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    internal class User
    {
        //public User(userInfo)
        //{

        //}
        public string selectedUser = "";
        public void User1()
        {
            selectedUser = "User1";
        }
        public void User2()
        {
            selectedUser = "User2";
        }
        public void User3()
        {
            selectedUser = "User3";
        }
        //get selected user
        public string SelectedUser()
        {
            return selectedUser;
        }

        //public void CleanUser()
        //{
        //    selectedUser = "";
        //}
    }
}
