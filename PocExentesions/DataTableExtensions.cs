using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocExentesions
{
    public static class DataTableExtensions
    {
        public static IEnumerable<T> Select<T>(this DataTable table) where T : ObjectMap<T>
        {
            T obj = Activator.CreateInstance<T>();
            List<T> list = new List<T>();
            foreach(DataRow row in table.Rows)
            {
                list.Add(obj.Map(row));
            }

            return list;
        }
    }
}
