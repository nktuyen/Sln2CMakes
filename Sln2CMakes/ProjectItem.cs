using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sln2CMakes
{
    public class ProjectItem
    {
        public string Name { get; internal set; }
        internal ProjectItem(string name = "")
        {
            Name = name;
        }
    }
}
