using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vs
{
    public class File : NamedObject
    {
        public string AbsolutePath { get; internal set; }
        public string RelativePath { get; internal set; }
        public string Extension { get; set; }
        public string Directory { get; internal set; }
        internal File(string name = ""): base(name)
        {

        }
    }
}
