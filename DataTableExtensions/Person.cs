using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocExentesions
{
    public class Person
    {
        [Entity("Teste")]
        public string Name { get; private set; }

        [Entity("Age")]
        public int Age { get; private set; }

        public Person() { }        
    }
}
