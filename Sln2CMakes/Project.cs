using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sln2CMakes
{
    public class Project : NamedObject
    {
        public string Path { get; internal set; }
        public string Guid { get; internal set; }
        public Solution Solution { get; internal set; }

        internal Project(string name = ""): base(name)
        {
            
        }
    }
}
