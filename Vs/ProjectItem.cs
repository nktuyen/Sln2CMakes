using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vs
{
    public class ProjectItem : File
    {
        public ProjectItem Parent { get; internal set; }
        internal ProjectItem(string name = "") : base(name)
        {
            
        }

        internal virtual void UpdateEnvironmentVariables()
        {

        }
    }
}
