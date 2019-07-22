using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vs
{
    public class Project : File
    {
        public string Guid { get; internal set; }
        public Solution Solution { get; internal set; }
        internal Project(string name = "", string guid = ""): base(name)
        {
            Guid = guid;
        }
    }
}
