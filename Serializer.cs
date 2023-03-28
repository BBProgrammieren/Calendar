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
    [Serializable]
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
        public void userSerializeNow(User user)  
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("MyFile.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, user);
            stream.Close();
        }

        public void appointmentSerializeNow(Appointments appointments)  
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("MyFile.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, appointments);
            stream.Close();
        }
        public (User, Appointments) DeSerializeNow()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("MyFile.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            try
            {
                appointments = (Appointments)formatter.Deserialize(stream);
                user = (User)formatter.Deserialize(stream);
            }
            catch (Exception ex)
            {
                user = new User();
                appointments = new Appointments();
            }
            finally
            {
                stream.Close();
            }
            return (user, appointments);
        }

        public User userDeSerializeNow()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("MyFile.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            try
            {
                 user = (User)formatter.Deserialize(stream);
            }
            catch (Exception ex)
            {
                 user = new User();
            }
            finally
            {
                stream.Close();            
            }
            return user;
        }

        public Appointments appointmentDeSerializeNow() 
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("MyFile.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            try
            {
                appointments = (Appointments)formatter.Deserialize(stream);
            }
            catch (Exception ex)
            {
                appointments = new Appointments();
            }
            finally
            {
                stream.Close();
            }
            return appointments;
        }
    }
}
