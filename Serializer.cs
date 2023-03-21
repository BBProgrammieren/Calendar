using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Calendar
{
    internal class Serializer
    {
        private User user;
        private Appointments appointments;
        public void SerializeNow(User user, Appointments appointments)
        {     
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("MyFile.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, user);
            formatter.Serialize(stream, appointments);
            stream.Close();
        }
        public (User, Appointments) DeSerializeNow()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("MyFile.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            User user = (User)formatter.Deserialize(stream);
            Appointments appointments = (Appointments)formatter.Deserialize(stream);
            stream.Close();
            return (user, appointments);
        }
    }
}
