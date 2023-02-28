using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    internal class Appointments
    {
        private Hashtable appointments;

        public Appointments() 
        {
            appointments = new Hashtable();
        }   

        public void addAppointment(DateTime dateTime, string str)
        {
            appointments.Add(dateTime, str);
        }
        public void deleteAppointment(DateTime dateTime)
        {
            appointments.Remove(dateTime);
        }

        public Boolean checkNull(DateTime dateTime)
        {
            if (appointments[dateTime] == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string getString(DateTime dateTime)
        {
            return appointments[dateTime].ToString();
        }
    }
}
