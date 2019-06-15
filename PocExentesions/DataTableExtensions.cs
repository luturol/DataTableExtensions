using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PocExentesions
{
    public static class DataTableExtensions
    {
        public static IEnumerable<T> Select<T>(this DataTable table)
        {
           var att = GetAnnotations(typeof(T));                        
            List<T> list = new List<T>();
            foreach(DataRow row in table.Rows)
            {
                T obj = Activator.CreateInstance<T>();
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    string columName = table.Columns[i].ColumnName;
                    if (att.ContainsKey(columName))
                    {
                        string propertyName = att[columName];
                        typeof(T).GetProperty(propertyName).SetValue(obj, row[columName]);
                    }
                }                
                list.Add(obj);
            }

            return list;
        }

        private static Dictionary<string, string> GetAnnotations(Type type)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                object[] attributes = property.GetCustomAttributes(true);
                foreach (object attr in attributes)
                {
                    if (attr is EntityAttribute entityAttribute)
                    {
                        string propName = property.Name;
                        string identifier = entityAttribute.Identifier;

                        dictionary.Add(identifier, propName);
                    }
                }
            }

            return dictionary;
        }
        
    }
}
