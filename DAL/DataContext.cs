using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataContext<T>
    {
        IDataProvider<T> dataProvider = new BinarySerializer<T>();

        public void Serialization(T t, int type)
        {
            dataProvider.WriteFile(t, type);
        }

        public T Deserialization(int type)
        {
            return dataProvider.ReadFile(type);
        }
    }
}
