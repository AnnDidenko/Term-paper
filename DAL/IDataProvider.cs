﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    interface IDataProvider<T>
    {
        void WriteFile(T t, int type);
        T ReadFile(int type);
    }
}
