using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    internal class Times 
    {
        private Hashtable table;
        private ArrayList times = new ArrayList();

        Times()
        {
            setTimes();
        }
        public void showTime()
        {
            foreach (var t in times)
            {
                Console.WriteLine(t.ToString());
            }
        }
        
        public void setTimes()
        {
            for (int i = 0; i < 24; i++)
            {
                this.times.Add(i + "o'clock");
            }                
        }
    }
}
