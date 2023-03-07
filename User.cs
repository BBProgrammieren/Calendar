using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    [Serializable]
    internal class User
    {
        [NonSerialized] private string name;

        private Appointments appointments;

        public User(string name)
        {
            this.name = name;
            appointments = new Appointments();      
        }
      
        //get selected user
        public string Name()
        {
            return name;
        }

       public Appointments getUserAppointment()
        {
            return appointments;
        }

        //public void CleanUser()
        //{
        //    selectedUser = "";
        //}
    }
}
