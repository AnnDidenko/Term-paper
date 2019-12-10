using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DAL
{
    public class BinarySerializer<T> : IDataProvider<T>
    {
        private string path;

        public string FindPath(int type)
        {
            if(type == 1)//Write clients
            {
                path = ConfigurationManager.AppSettings["pathForClients"];
            }
            else if(type == 2)//Write realty
            {
                path = ConfigurationManager.AppSettings["pathForRealty"];
            }
            return path;
        }

        public void WriteFile(T t, int type)
        {
            using (FileStream fs = new FileStream(FindPath(type), FileMode.OpenOrCreate))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, t);
            }
        }

        public T ReadFile(int type)
        {
            T objects;
            using (FileStream fs = new FileStream(FindPath(type), FileMode.OpenOrCreate))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                objects = (T)formatter.Deserialize(fs);
            }
            return objects;
        }
    }
}
