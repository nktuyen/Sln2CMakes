using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vs
{
    public class Property: NamedObject
    {
        public string Value { get; internal set; }

        internal Property(string name = "", string val = ""): base(name)
        {
            this.Value = val;
        }
    }
}
