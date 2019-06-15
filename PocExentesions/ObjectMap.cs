using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocExentesions
{
    public abstract class ObjectMap<T>
    {
        public abstract T Map(DataRow row);
    }
}
