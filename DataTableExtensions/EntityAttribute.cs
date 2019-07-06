using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocExentesions
{
    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    public sealed class EntityAttribute : Attribute
    {
        public string Identifier { get; set; }
        
        public EntityAttribute(string name)
        {
            this.Identifier = name;            
        }
        
    }
}
