using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sln2CMakes
{
    public class Model
    {
        public Model Parent { get; internal set; }
        public string Name { get; internal set; }
        public bool IsValid { get; protected set; }

        internal Model()
        {

        }

        internal virtual void Validate() { IsValid = true; }
    }
}
