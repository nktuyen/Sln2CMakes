using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sln2CMakes
{
    public abstract class NamedObject
    {
        public string Name { get; protected set; }

        internal NamedObject(string name = "")
        {
            Name = name;
        }
    }
}
