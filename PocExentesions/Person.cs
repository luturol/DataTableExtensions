using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocExentesions
{
    public class Person : ObjectMap<Person>
    {
        public string Name { get; private set; }
        public int Age { get; private set; }

        public Person() { }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public override Person Map(DataRow row)
        {
            return new Person(row["Name"].ToString(), int.Parse( row["Age"].ToString()));
        }
    }
}
