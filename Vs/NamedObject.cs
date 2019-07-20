using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vs
{
    public abstract class NamedObject
    {
        public string Name { get; internal set; }

        internal NamedObject(string name = "")
        {
            Name = name;
        }
    }
}
